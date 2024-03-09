namespace SampleApp1.Web.ViewModels.Artists
{
    public record ArtistMinifiedViewModel
    {
        public required Guid Id { get; init; }
        public required string Nickname { get; init; }
    }
}
