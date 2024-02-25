namespace SampleApp1.Data.Models
{
    public class Song
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public Guid ArtistId { get; set; }
        public Artist Artist { get; set; } // Navigation property
    }
}
