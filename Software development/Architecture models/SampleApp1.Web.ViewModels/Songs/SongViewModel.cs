using SampleApp1.Web.ViewModels.Artists;
using SampleApp1.Web.ViewModels.Genres;

namespace SampleApp1.Web.ViewModels.Songs
{
    public record SongViewModel
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
        public required ArtistMinifiedViewModel Artist { get; init; }
        public required IEnumerable<GenreMinifiedViewModel> Genres { get; init; }
    }
}
