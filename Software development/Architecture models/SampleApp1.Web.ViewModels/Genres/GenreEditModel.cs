namespace SampleApp1.Web.ViewModels.Genres
{
    public record GenreEditModel : GenreCreateModel
    {
        public required Guid Id { get; init; }
    }
}
