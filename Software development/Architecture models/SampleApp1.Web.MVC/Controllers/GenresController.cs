using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SampleApp1.Core.Interfaces.Services;
using SampleApp1.Data.Models;
using SampleApp1.Web.ViewModels.Genres;

namespace SampleApp1.Web.MVC.Controllers
{
    [Route("genres")]
    public class GenresController : Controller
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public GenresController(IGenreService genreService, IMapper mapper)
        {
            this._genreService = genreService ?? throw new ArgumentNullException(nameof(genreService));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult Index()
        {
            var genres = this._genreService.GetAll();
            var viewModels = this._mapper.Map<IEnumerable<GenreViewModel>>(genres);

            return this.View(viewModels);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost("create"), ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] GenreCreateModel inputModel)
        {
            if (!ModelState.IsValid) return this.View(inputModel);

            var genre = this._mapper.Map<Genre>(inputModel);
            this._genreService.Create(genre);

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet("delete")]
        public IActionResult Delete(Guid id)
        {
            var genre = this._genreService.GetOneMinified(id);
            if (genre is null) return this.NotFound();

            var viewModel = this._mapper.Map<GenreMinifiedViewModel>(genre);
            return this.View(viewModel);
        }

        [HttpPost("delete"), ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            this._genreService.Delete(id);
            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet("details")]
        public IActionResult Details(Guid id)
        {
            var genre = this._genreService.GetOne(id);
            if (genre is null) return this.NotFound();

            var viewModel = this._mapper.Map<GenreViewModel>(genre);
            return this.View(viewModel);
        }

        [HttpGet("edit")]
        public IActionResult Edit(Guid id)
        {
            var genre = this._genreService.GetOneEdit(id);
            if (genre is null) return this.NotFound();

            var viewModel = this._mapper.Map<GenreEditModel>(genre);
            return View(viewModel);
        }

        [HttpPost("edit"), ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, GenreEditModel inputModel)
        {
            if (!ModelState.IsValid) return this.View(inputModel);
            if (id != inputModel.Id) return this.NotFound();

            var genre = this._genreService.GetById(id);
            if (genre is null) return this.NotFound();

            this._mapper.Map(inputModel, genre);
            this._genreService.Update(genre);

            return this.RedirectToAction(nameof(Index));
        }
    }
}
