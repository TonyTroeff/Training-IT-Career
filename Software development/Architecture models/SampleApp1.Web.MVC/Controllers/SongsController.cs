using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SampleApp1.Core.Interfaces.Services;
using SampleApp1.Data.Models;
using SampleApp1.Web.ViewModels.Artists;
using SampleApp1.Web.ViewModels.Genres;
using SampleApp1.Web.ViewModels.Songs;

namespace SampleApp1.Web.MVC.Controllers
{
    [Route("songs")]
    public class SongsController : Controller
    {
        private readonly IArtistService _artistService;
        private readonly IGenreService _genreService;
        private readonly ISongService _songService;
        private readonly IMapper _mapper;

        public SongsController(IArtistService artistService, IGenreService genreService, ISongService songService, IMapper mapper)
        {
            this._artistService = artistService ?? throw new ArgumentNullException(nameof(artistService));
            this._genreService = genreService ?? throw new ArgumentNullException(nameof(genreService));
            this._songService = songService ?? throw new ArgumentNullException(nameof(songService));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult Index()
        {
            var allSongs = this._songService.GetAll();
            var viewModels = this._mapper.Map<IEnumerable<SongViewModel>>(allSongs);

            return this.View(viewModels);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            var viewModel = this.PrepareFormViewModel();
            return this.View(viewModel);
        }

        [HttpPost("create"), ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] SongCreateModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = this.PrepareFormViewModel(inputModel);
                return this.View(viewModel);
            }

            var artist = this._artistService.GetById(inputModel.Artist);
            if (artist is null) throw new InvalidOperationException("Artist not found");

            var genres = this._genreService.GetByIds(inputModel.Genres).ToArray();
            if (genres.Length != inputModel.Genres.Length)
                throw new InvalidOperationException("Some of the genres are not found.");

            var song = this._mapper.Map<Song>(inputModel);
            song.Artist = artist;
            song.Genres = genres;

            this._songService.Create(song);

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet("delete")]
        public IActionResult Delete(Guid id)
        {
            var song = this._songService.GetOneMinified(id);
            if (song is null) return this.NotFound();

            var viewModel = this._mapper.Map<SongMinifiedViewModel>(song);
            return this.View(viewModel);
        }

        [HttpPost("delete"), ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            this._songService.Delete(id);
            return this.RedirectToAction(nameof(Index));
        }

        private SongFormViewModel PrepareFormViewModel(SongCreateModel? inputModel = null)
        {
            var allArtists = this._artistService.GetAllMinified();
            var allGenres = this._genreService.GetAllMinified();

            return new SongFormViewModel
            {
                Artists = this._mapper.Map<IEnumerable<ArtistMinifiedViewModel>>(allArtists),
                Genres = this._mapper.Map<IEnumerable<GenreMinifiedViewModel>>(allGenres),
                InputModel = inputModel
            };
        }
    }
}
