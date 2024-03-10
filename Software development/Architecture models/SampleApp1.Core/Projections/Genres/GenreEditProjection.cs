namespace SampleApp1.Core.Projections.Genres
{
    public record GenreEditProjection
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
    }
}
