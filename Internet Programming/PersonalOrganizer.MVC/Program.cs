using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PersonalOrganizer.Core.Authentication;
using PersonalOrganizer.Core.Authentication.Abstractions;
using PersonalOrganizer.Core.Services;
using PersonalOrganizer.Core.Services.Abstractions;
using PersonalOrganizer.Data;
using PersonalOrganizer.Data.Repositories;
using PersonalOrganizer.Data.Repositories.Abstractions;
using PersonalOrganizer.MVC.Middlewares;
using System.Reflection;

namespace PersonalOrganizer.MVC;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddDefaultIdentity<IdentityUser>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        Assembly currentAssembly = Assembly.GetExecutingAssembly();
        builder.Services.AddAutoMapper(currentAssembly);

        // Add dependencies
        builder.Services.AddScoped<IAuthenticationContext, AuthenticationContext>();
        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        builder.Services.AddScoped<ITaskItemService, TaskItemService>();
        builder.Services.AddScoped<ITaskGroupService, TaskGroupService>();
        builder.Services.AddScoped<ILabelService, LabelService>();
        
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.MapStaticAssets();
       
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseMiddleware<AuthenticationContextSetupMiddleware>();

        app.MapControllers();
        app.MapRazorPages().WithStaticAssets();

        app.Run();
    }
}
