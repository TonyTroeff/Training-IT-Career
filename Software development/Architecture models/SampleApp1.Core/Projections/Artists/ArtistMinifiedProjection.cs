namespace SampleApp1.Core.Projections.Artists
{
    public record ArtistMinifiedProjection
    {
        public required Guid Id { get; init; }
        public required string Nickname { get; init; }
    }
}
