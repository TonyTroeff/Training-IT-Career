namespace SampleApp1.Data.Models
{
    public class Artist : IIdentifiable
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Nickname { get; set; } = string.Empty;

        public ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}
