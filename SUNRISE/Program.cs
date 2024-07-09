using Microsoft.EntityFrameworkCore;
using SUNRISE.Models;
using Microsoft.AspNetCore.Identity;
using SUNRISE;
using SUNRISE.Seeders;

namespace SUNRISE
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // DbContext Configuration & Injection
            var connectionString = builder.Configuration.GetConnectionString("DevelopmentConnection") ?? throw new InvalidOperationException("Connection string 'DevelopmentConnection' not found.");

            builder.Services.AddDbContext<ApplicationDbContext>(dbOptionsBuilder =>
            dbOptionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer(connectionString));

            builder.Services
                .AddIdentity<ApplicationUserEntity, ApplicationUserRoleEntity>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.ConfigureApplicationCookie(c =>
            {
                c.LoginPath = "/Identity/Account/Login";
                c.LogoutPath= "/Identity/Account/Logout";
            });

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();


            #region Identity Seeding
            // Identity Seeding
            using (var scope = app.Services.CreateScope())
                await DbRoleSeeder.SeedRolesAsync(scope.ServiceProvider);
            #endregion

            await app.RunAsync();
        }
    }
}
