using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PersonalOrganizer.Core.Prototypes;
using PersonalOrganizer.Core.Services.Abstractions;
using PersonalOrganizer.Data.Models;
using PersonalOrganizer.MVC.Models.TaskItems;

namespace PersonalOrganizer.MVC.Controllers;

[Route("tasks")]
public class TaskItemsController(ITaskItemService taskItemService, ITaskGroupService taskGroupService, ILabelService labelService, IMapper mapper) : Controller
{
    private readonly ITaskItemService _taskItemService = taskItemService ?? throw new ArgumentNullException(nameof(taskItemService));
    private readonly ITaskGroupService _taskGroupService = taskGroupService ?? throw new ArgumentNullException(nameof(taskGroupService));
    private readonly ILabelService _labelService = labelService ?? throw new ArgumentNullException(nameof(labelService));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        TaskItem[] taskItems = await this._taskItemService.GetAllWithNavigationsAsync([nameof(TaskItem.Group), nameof(TaskItem.Labels)], cancellationToken);

        TaskItemViewModel[] viewModels = this._mapper.Map<TaskItemViewModel[]>(taskItems);
        return this.View(viewModels);
    }

    [HttpGet("details/{id:guid}")]
    public async Task<IActionResult> Details([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        TaskItem? taskItem = await this._taskItemService.GetByIdWithNavigationsAsync(id, [nameof(TaskItem.Group), nameof(TaskItem.Labels)], cancellationToken);
        if (taskItem is null) return this.NotFound();

        TaskItemViewModel viewModel = this._mapper.Map<TaskItemViewModel>(taskItem);
        return this.View(viewModel);
    }

    [HttpGet("create")]
    public async Task<IActionResult> Create(CancellationToken cancellationToken)
    {
        await this.LoadReferencesInViewDataAsync(cancellationToken);
        return this.View();
    }

    [HttpPost("create"), ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([FromForm] TaskItemInputModel inputModel, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            await this.LoadReferencesInViewDataAsync(cancellationToken);
            return this.View(inputModel);
        }

        TaskItemPrototype prototype = this._mapper.Map<TaskItemPrototype>(inputModel);
        await this._taskItemService.CreateAsync(prototype, cancellationToken);

        return this.RedirectToAction(nameof(Index));
    }

    [HttpGet("edit/{id:guid}")]
    public async Task<IActionResult> Edit([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        TaskItem? taskItem = await this._taskItemService.GetByIdWithNavigationsAsync(id, [nameof(TaskItem.Labels)], cancellationToken);
        if (taskItem is null) return this.NotFound();

        TaskItemInputModel inputModel = this._mapper.Map<TaskItemInputModel>(taskItem);
        
        await this.LoadReferencesInViewDataAsync(cancellationToken);
        return this.View(inputModel);
    }

    [HttpPost("edit/{id:guid}"), ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit([FromRoute] Guid id, [FromForm] TaskItemInputModel inputModel, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            await this.LoadReferencesInViewDataAsync(cancellationToken);
            return this.View(inputModel);
        }

        TaskItem? taskItem = await this._taskItemService.GetByIdAsync(id, cancellationToken);
        if (taskItem is null) return this.NotFound();

        TaskItemPrototype prototype = this._mapper.Map<TaskItemPrototype>(inputModel);
        await this._taskItemService.UpdateAsync(id, prototype, cancellationToken);

        return this.RedirectToAction(nameof(Index));
    }

    [HttpGet("delete/{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        TaskItem? taskItem = await this._taskItemService.GetByIdWithNavigationsAsync(id, [nameof(TaskItem.Group), nameof(TaskItem.Labels)], cancellationToken);
        if (taskItem is null) return this.NotFound();

        TaskItemViewModel viewModel = this._mapper.Map<TaskItemViewModel>(taskItem);
        return this.View(viewModel);
    }

    [HttpPost("delete/{id:guid}"), ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        TaskItem? taskItem = await this._taskItemService.GetByIdAsync(id, cancellationToken);
        if (taskItem is null) return this.NotFound();

        await this._taskItemService.SoftDeleteAsync(id, cancellationToken);
        return this.RedirectToAction(nameof(Index));
    }

    private async Task LoadReferencesInViewDataAsync(CancellationToken cancellationToken)
    {
        TaskGroup[] allGroups = await this._taskGroupService.GetAllAsync(cancellationToken);
        this.ViewData["Groups"] = this._mapper.Map<SelectListItem[]>(allGroups);

        Label[] allLabels = await this._labelService.GetAllAsync(cancellationToken);
        this.ViewData["Labels"] = this._mapper.Map<SelectListItem[]>(allLabels);
    }
}
