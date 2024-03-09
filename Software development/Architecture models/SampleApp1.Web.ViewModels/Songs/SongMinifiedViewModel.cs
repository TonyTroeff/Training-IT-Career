namespace SampleApp1.Web.ViewModels.Songs
{
    public record SongMinifiedViewModel
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
    }
}
