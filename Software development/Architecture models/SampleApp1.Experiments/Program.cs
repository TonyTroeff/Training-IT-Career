using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SampleApp1.Core.Interfaces.Services;
using SampleApp1.Core.Projections.Songs;
using SampleApp1.Core.Services;
using SampleApp1.Data;
using SampleApp1.Data.Models;
using SampleApp1.Data.Repositories;

namespace SampleApp1.Experiments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=localhost;Database=music;Uid=root;Pwd=root;";
            using SampleDbContext dbContext = InitializeDatabase(connectionString);

            IRepository<Song> songRepository = new Repository<Song>(dbContext);
            ISongService songService = new SongService(songRepository);

            IRepository<Genre> genreRepository = new Repository<Genre>(dbContext);
            IGenreService genreService = new GenreService(genreRepository);

            IRepository<Artist> artistRepository = new Repository<Artist>(dbContext);
            IArtistService artistService = new ArtistService(artistRepository);

            bool continueProcessingInput = true;
            while (continueProcessingInput)
            {
                dbContext.ChangeTracker.Clear();

                PrintMenu();
                string input = Console.ReadLine().Trim();

                if (input == "1") CreateSong(songService, genreService);
                else if (input == "2") GetAllSongs(songService);
                else if (input == "3") CreateArtist(artistService);
                else if (input == "4") GetAllArtists(artistService);
                else if (input == "5") CreateGenre(genreService);
                else if (input == "6") GetAllGenres(genreService);
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
            Console.WriteLine("4. Get all artists with their songs");
            Console.WriteLine("5. Create genre");
            Console.WriteLine("6. Get all genres");
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
            // dbContext.Database.EnsureDeleted();
            // dbContext.Database.EnsureCreated();
            dbContext.Database.Migrate();

            return dbContext;
        }

        private static void CreateSong(ISongService songService, IGenreService genreService)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Artist ID: ");
            Guid artistId = Guid.Parse(Console.ReadLine());

            Console.Write("Genre IDs (separated by ', '): ");
            Guid[] genreIds = Console.ReadLine().Split(", ").Select(Guid.Parse).ToArray();

            Genre[] genres = genreService.GetByIds(genreIds).ToArray();
            if (genres.Length != genreIds.Length)
            {
                Console.WriteLine("Some of the genres could not be found. The song will not be created.");
                return;
            }

            Song songToCreate = new Song { Name = name, ArtistId = artistId, Genres = genres };

            songService.Create(songToCreate);

            Console.WriteLine($"Song was created successfully! ID: {songToCreate.Id}");
        }

        //private static void GetAllSongs(SampleDbContext dbContext)
        //{
        //    // How to download data from referenced tables?
        //    // 1. Include(..)
        //    // List<Song> allSongs = dbContext.Songs.Include(x => x.Artist).ToList();
        //    // foreach (var song in allSongs)
        //    //     Console.WriteLine($"{song.Id}: \"{song.Name}\", {song.ArtistNickname}");

        //    // 2. Select(..) with anonymous type(s)
        //    // var allSongs = dbContext.Songs.Select(x => new { Id = x.Id, Name = x.Name, ArtistNickname = x.Artist.Nickname }).ToList();
        //    // foreach (var song in allSongs)
        //    //     Console.WriteLine($"{song.Id}: \"{song.Name}\", {song.ArtistNickname}");

        //     3. Select(..) with static type(s)
        //     List<SongInfoProjection> allSongs = dbContext.Songs.Select(x => new SongInfoProjection { Id = x.Id, Name = x.Name, ArtistNickname = x.Artist.Nickname }).ToList();
        //     foreach (var song in allSongs)
        //         Console.WriteLine($"{song.Id}: \"{song.Name}\", {song.ArtistNickname}");
        //}

        private static void GetAllSongs(ISongService songService)
        {
            List<SongGeneralInfoProjection> allSongs = songService.GetAll().ToList();
            foreach (var song in allSongs)
                Console.WriteLine($"{song.Id}: \"{song.Name}\", {song.Artist.Nickname}");
        }

        private static void CreateArtist(IArtistService artistService)
        {
            Console.Write("First name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Nickname: ");
            string nickname = Console.ReadLine();

            Artist artistToCreate = new Artist { FirstName = firstName, LastName = lastName, Nickname = nickname, };
            artistService.Create(artistToCreate);

            Console.WriteLine($"Artist was created successfully! ID: {artistToCreate.Id}");
        }

        //private static void GetAllArtists(SampleDbContext dbContext)
        //{
        //    // 1. Include(..)
        //    //List<Artist> allArtists = dbContext.Artists
        //    //    .Include(x => x.Songs.OrderBy(y => y.Name))
        //    //    .OrderBy(x => x.Nickname)
        //    //    .ToList();

        //    //foreach (Artist artist in allArtists)
        //    //{
        //    //    Console.WriteLine($"{artist.Id}: {artist.Nickname} ({artist.FirstName} {artist.LastName})");
        //    //    foreach (Song song in artist.Songs)
        //    //        Console.WriteLine($"--> {song.Id}: {song.Name}");
        //    //}

        //    // 2. Select(..) with anonymous type(s)
        //    var allArtists = dbContext.Artists
        //        .Select(a => new
        //        {
        //            a.Id,
        //            a.Nickname,
        //            a.FirstName,
        //            a.LastName,
        //            Songs = a.Songs.Select(s => new { s.Id, s.Name }).OrderBy(s => s.Name).ToList(),
        //        })
        //        .OrderBy(a => a.Nickname)
        //        .ToList();

        //    foreach (var artist in allArtists)
        //    {
        //        Console.WriteLine($"{artist.Id}: {artist.Nickname} ({artist.FirstName} {artist.LastName})");
        //        foreach (var song in artist.Songs)
        //            Console.WriteLine($"--> {song.Id}: {song.Name}");
        //    }
        //}

        private static void GetAllArtists(IArtistService artistService)
        {
            var allArtists = artistService.GetAll();

            foreach (var artist in allArtists)
            {
                Console.WriteLine($"{artist.Id}: {artist.Nickname} ({artist.FirstName} {artist.LastName})");
                foreach (var song in artist.Songs)
                    Console.WriteLine($"--> {song.Id}: {song.Name}");
            }
        }

        private static void CreateGenre(IGenreService genreService)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Genre genreToCreate = new Genre { Name = name };
            genreService.Create(genreToCreate);

            Console.WriteLine($"Genre was created successfully! ID: {genreToCreate.Id}");
        }

        private static void GetAllGenres(IGenreService genreService)
        {
            var allGenres = genreService.GetAll();

            foreach (var genre in allGenres)
                Console.WriteLine($"{genre.Id}: {genre.Name}");
        }
    }
}
