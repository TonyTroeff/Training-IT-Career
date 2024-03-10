using Microsoft.Extensions.DependencyInjection;
using SampleApp1.Core.Interfaces.Services;
using SampleApp1.Core.Services;
using SampleApp1.Data.Models;
using SampleApp1.Data.Repositories;

namespace SampleApp1.Core.Configuration
{
    public static class ConfigurationExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            if (services is null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<IRepository<Artist>, Repository<Artist>>();
            services.AddScoped<IArtistService, ArtistService>();

            services.AddScoped<IRepository<Genre>, Repository<Genre>>();
            services.AddScoped<IGenreService, GenreService>();

            services.AddScoped<IRepository<Song>, Repository<Song>>();
            services.AddScoped<ISongService, SongService>();
        }
    }
}
