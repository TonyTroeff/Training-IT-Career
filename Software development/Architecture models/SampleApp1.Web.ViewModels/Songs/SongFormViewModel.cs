using SampleApp1.Web.ViewModels.Artists;
using SampleApp1.Web.ViewModels.Genres;

namespace SampleApp1.Web.ViewModels.Songs
{
    public record SongFormViewModel
    {
        public required IEnumerable<ArtistMinifiedViewModel> Artists { get; init; }
        public required IEnumerable<GenreMinifiedViewModel> Genres { get; init; }
        public SongCreateModel? InputModel { get; init; }
    }
}
