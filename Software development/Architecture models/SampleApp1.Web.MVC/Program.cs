using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SampleApp1.Core.Interfaces.Services;
using SampleApp1.Core.Projections.Genres;
using SampleApp1.Core.Services;
using SampleApp1.Data;
using SampleApp1.Data.Models;
using SampleApp1.Data.Repositories;
using SampleApp1.Web.ViewModels.Genres;
using System.Reflection;

namespace SampleApp1.Web.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            RegisterDbContext(builder);
            RegisterServices(builder);
            RegisterAutoMapper(builder);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        private static void RegisterDbContext(WebApplicationBuilder builder)
        {
            // TODO: Read from appsettings.json!
            const string connectionString = "Server=localhost;Database=music;Uid=root;Pwd=root;";

            builder.Services.AddDbContext<SampleDbContext>(options =>
            {
#if DEBUG
                options.EnableSensitiveDataLogging(sensitiveDataLoggingEnabled: true);
#endif

                options.UseMySQL(connectionString);
            });
        }

        private static void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IRepository<Artist>, Repository<Artist>>();
            builder.Services.AddScoped<IArtistService, ArtistService>();

            builder.Services.AddScoped<IRepository<Genre>, Repository<Genre>>();
            builder.Services.AddScoped<IGenreService, GenreService>();

            builder.Services.AddScoped<IRepository<Song>, Repository<Song>>();
            builder.Services.AddScoped<ISongService, SongService>();
        }

        private static void RegisterAutoMapper(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
