namespace SampleApp1.Web.ViewModels.Genres
{
    public record GenreViewModel
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
    }
}
