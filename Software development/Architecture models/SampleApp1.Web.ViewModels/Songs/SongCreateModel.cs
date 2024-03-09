namespace SampleApp1.Web.ViewModels.Songs
{
    public record SongCreateModel
    {
        public required string Name { get; init; }
        public required Guid Artist { get; init; }
        public required Guid[] Genres { get; init; }
    }
}
