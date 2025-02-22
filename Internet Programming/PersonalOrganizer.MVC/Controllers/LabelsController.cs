using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonalOrganizer.Core.Prototypes;
using PersonalOrganizer.Core.Services.Abstractions;
using PersonalOrganizer.Data.Models;
using PersonalOrganizer.MVC.Models.Labels;
using PersonalOrganizer.MVC.Models.TaskGroups;
using PersonalOrganizer.MVC.Models.TaskItems;

namespace PersonalOrganizer.MVC.Controllers;

[Route("labels")]
public class LabelsController(ILabelService labelService, IMapper mapper) : Controller
{
    private readonly ILabelService _labelService = labelService ?? throw new ArgumentNullException(nameof(labelService));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        Label[] labels = await this._labelService.GetAllAsync(cancellationToken);

        LabelViewModel[] viewModels = this._mapper.Map<LabelViewModel[]>(labels);
        return this.View(viewModels);
    }

    [HttpGet("details/{id:guid}")]
    public async Task<IActionResult> Details([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        Label? label = await this._labelService.GetByIdAsync(id, cancellationToken);
        if (label is null) return this.NotFound();

        LabelViewModel viewModel = this._mapper.Map<LabelViewModel>(label);
        return this.View(viewModel);
    }

    [HttpGet("create")]
    public IActionResult Create() => this.View();

    [HttpPost("create"), ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([FromForm] LabelInputModel inputModel, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return this.View(inputModel);

        LabelPrototype prototype = this._mapper.Map<LabelPrototype>(inputModel);
        await this._labelService.CreateAsync(prototype, cancellationToken);

        return this.RedirectToAction(nameof(Index));
    }

    [HttpGet("edit/{id:guid}")]
    public async Task<IActionResult> Edit([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        Label? label = await this._labelService.GetByIdAsync(id, cancellationToken);
        if (label is null) return this.NotFound();

        LabelInputModel inputModel = this._mapper.Map<LabelInputModel>(label);
        return this.View(inputModel);
    }

    [HttpPost("edit/{id:guid}"), ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit([FromRoute] Guid id, [FromForm] LabelInputModel inputModel, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return this.View(inputModel);

        Label? label = await this._labelService.GetByIdAsync(id, cancellationToken);
        if (label is null) return this.NotFound();

        LabelPrototype prototype = this._mapper.Map<LabelPrototype>(inputModel);
        await this._labelService.UpdateAsync(id, prototype, cancellationToken);

        return this.RedirectToAction(nameof(Index));
    }

    [HttpGet("delete/{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        Label? label = await this._labelService.GetByIdAsync(id, cancellationToken);
        if (label is null) return this.NotFound();

        LabelViewModel viewModel = this._mapper.Map<LabelViewModel>(label);
        return this.View(viewModel);
    }

    [HttpPost("delete/{id:guid}"), ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        Label? label = await this._labelService.GetByIdAsync(id, cancellationToken);
        if (label is null) return this.NotFound();

        await this._labelService.SoftDeleteAsync(id, cancellationToken);
        return this.RedirectToAction(nameof(Index));
    }
}
