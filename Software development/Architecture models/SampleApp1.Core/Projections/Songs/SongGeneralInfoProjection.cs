namespace SampleApp1.Core.Projections.Songs
{
    public record SongGeneralInfoProjection
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
        public required string ArtistNickname { get; init; }
    }
}
