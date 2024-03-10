using SampleApp1.Web.ViewModels.Artists;
using SampleApp1.Web.ViewModels.Genres;

namespace SampleApp1.Web.ViewModels.Songs
{
    public record SongFormViewModel<TInputModel>
    {
        public required IEnumerable<ArtistMinifiedViewModel> Artists { get; init; }
        public required IEnumerable<GenreMinifiedViewModel> Genres { get; init; }
        public TInputModel? InputModel { get; init; }
    }
}
