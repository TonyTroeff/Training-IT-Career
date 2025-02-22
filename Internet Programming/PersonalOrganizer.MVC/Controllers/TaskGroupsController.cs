using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonalOrganizer.Core.Prototypes;
using PersonalOrganizer.Core.Services.Abstractions;
using PersonalOrganizer.Data.Models;
using PersonalOrganizer.MVC.Models.TaskGroups;
using PersonalOrganizer.MVC.Models.TaskItems;

namespace PersonalOrganizer.MVC.Controllers;

[Route("groups")]
public class TaskGroupsController(ITaskGroupService taskGroupService, IMapper mapper) : Controller
{
    private readonly ITaskGroupService _taskGroupService = taskGroupService ?? throw new ArgumentNullException(nameof(taskGroupService));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        TaskGroup[] taskGroups = await this._taskGroupService.GetAllAsync(cancellationToken);

        TaskGroupViewModel[] viewModels = this._mapper.Map<TaskGroupViewModel[]>(taskGroups);
        return this.View(viewModels);
    }

    [HttpGet("details/{id:guid}")]
    public async Task<IActionResult> Details([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        TaskGroup? taskGroup = await this._taskGroupService.GetByIdAsync(id, cancellationToken);
        if (taskGroup is null) return this.NotFound();

        TaskGroupViewModel viewModel = this._mapper.Map<TaskGroupViewModel>(taskGroup);
        return this.View(viewModel);
    }

    [HttpGet("create")]
    public IActionResult Create() => this.View();

    [HttpPost("create"), ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([FromForm] TaskGroupInputModel inputModel, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return this.View(inputModel);

        TaskGroupPrototype prototype = this._mapper.Map<TaskGroupPrototype>(inputModel);
        await this._taskGroupService.CreateAsync(prototype, cancellationToken);

        return this.RedirectToAction(nameof(Index));
    }

    [HttpGet("edit/{id:guid}")]
    public async Task<IActionResult> Edit([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        TaskGroup? taskGroup = await this._taskGroupService.GetByIdAsync(id, cancellationToken);
        if (taskGroup is null) return this.NotFound();

        TaskGroupInputModel inputModel = this._mapper.Map<TaskGroupInputModel>(taskGroup);
        return this.View(inputModel);
    }

    [HttpPost("edit/{id:guid}"), ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit([FromRoute] Guid id, [FromForm] TaskGroupInputModel inputModel, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return this.View(inputModel);

        TaskGroup? taskGroup = await this._taskGroupService.GetByIdAsync(id, cancellationToken);
        if (taskGroup is null) return this.NotFound();

        TaskGroupPrototype prototype = this._mapper.Map<TaskGroupPrototype>(inputModel);
        await this._taskGroupService.UpdateAsync(id, prototype, cancellationToken);

        return this.RedirectToAction(nameof(Index));
    }

    [HttpGet("delete/{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        TaskGroup? taskGroup = await this._taskGroupService.GetByIdAsync(id, cancellationToken);
        if (taskGroup is null) return this.NotFound();

        TaskGroupViewModel viewModel = this._mapper.Map<TaskGroupViewModel>(taskGroup);
        return this.View(viewModel);
    }

    [HttpPost("delete/{id:guid}"), ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        TaskGroup? taskGroup = await this._taskGroupService.GetByIdAsync(id, cancellationToken);
        if (taskGroup is null) return this.NotFound();

        await this._taskGroupService.SoftDeleteAsync(id, cancellationToken);
        return this.RedirectToAction(nameof(Index));
    }
}
