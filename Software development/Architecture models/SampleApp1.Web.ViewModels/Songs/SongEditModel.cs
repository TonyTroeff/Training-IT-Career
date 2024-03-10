namespace SampleApp1.Web.ViewModels.Songs
{
    public record SongEditModel : SongCreateModel
    {
        public required Guid Id { get; init; }
    }
}
