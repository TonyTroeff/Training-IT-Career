namespace SampleApp1.Core.Projections.Songs
{
    public record SongEditProjection
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
        public required Guid ArtistId { get; init; }
        public required IEnumerable<Guid> GenreIds { get; init; }
    }
}
