using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SampleApp1.Data;
using SampleApp1.Data.Models;

namespace SampleApp1.Experiments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=localhost;Database=music;Uid=root;Pwd=root;";
            using SampleDbContext dbContext = InitializeDatabase(connectionString);

            bool continueProcessingInput = true;
            while (continueProcessingInput)
            {
                dbContext.ChangeTracker.Clear();

                PrintMenu();
                string input = Console.ReadLine().Trim();

                if (input == "1") CreateSong(dbContext);
                else if (input == "2") GetAllSongs(dbContext);
                else if (input == "3") CreateArtist(dbContext);
                else if (input == "0") continueProcessingInput = false;
                else Console.WriteLine("Invalid input!");

                Console.WriteLine();
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("1. Create song");
            Console.WriteLine("2. Get all songs");
            Console.WriteLine("3. Create artist");
            Console.WriteLine("0. Exit");
        }

        private static SampleDbContext InitializeDatabase(string connectionString)
        {
            DbContextOptionsBuilder<SampleDbContext> optionsBuilder = new DbContextOptionsBuilder<SampleDbContext>();

#if DEBUG
            optionsBuilder.EnableSensitiveDataLogging(sensitiveDataLoggingEnabled: true);
#endif

            optionsBuilder.LogTo(Console.WriteLine, minimumLevel: LogLevel.Information);
            optionsBuilder.UseMySQL(connectionString);

            SampleDbContext dbContext = new SampleDbContext(optionsBuilder.Options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            return dbContext;
        }

        private static void CreateSong(SampleDbContext dbContext)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Artist ID: ");
            Guid artistId = Guid.Parse(Console.ReadLine());

            Song songToCreate = new Song { Name = name, ArtistId = artistId };

            // Create - Add, Save Changes
            dbContext.Songs.Add(songToCreate);
            dbContext.SaveChanges();

            Console.WriteLine($"Song was created successfully! ID: {songToCreate.Id}");
        }

        private static void GetAllSongs(SampleDbContext dbContext)
        {
            List<Song> allSongs = dbContext.Songs.ToList();

            foreach (var song in allSongs)
                Console.WriteLine($"{song.Id}: \"{song.Name}\", {song.Artist.Nickname}");
        }

        private static void CreateArtist(SampleDbContext dbContext)
        {
            Console.Write("First name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Nickname: ");
            string nickname = Console.ReadLine();

            Artist artistToCreate = new Artist { FirstName = firstName, LastName = lastName, Nickname = nickname, };
            dbContext.Artists.Add(artistToCreate);
            dbContext.SaveChanges();

            Console.WriteLine($"Artist was created successfully! ID: {artistToCreate.Id}");
        }
    }
}
