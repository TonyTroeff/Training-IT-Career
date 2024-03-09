namespace SampleApp1.Core.Projections.Songs
{
    public record SongMinifiedProjection
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
    }
}
