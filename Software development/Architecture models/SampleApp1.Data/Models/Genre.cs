namespace SampleApp1.Data.Models
{
    public class Genre : IIdentifiable
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}
