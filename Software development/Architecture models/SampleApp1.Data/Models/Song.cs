namespace SampleApp1.Data.Models
{
    public class Song : IIdentifiable
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public Guid ArtistId { get; set; }
        public Artist Artist { get; set; } = null!; // Navigation property

        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
    }
}
