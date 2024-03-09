using System.ComponentModel;

namespace SampleApp1.Web.ViewModels.Genres
{
    public record GenreViewModel
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }

        [DisplayName("Count of artists")]
        public required long ArtistsCount { get; init; }

        [DisplayName("Count of songs")]
        public required long SongsCount { get; init; }
    }
}
