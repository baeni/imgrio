using Fordele.Blazor.Backend.Services;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Fordele.Blazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddControllers();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.Name = "Fordele.Auth";
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                    options.SlidingExpiration = true;
                    options.LoginPath = "/u/sign-in";
                    options.LogoutPath = "/u/sign-out";
                });
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddTransient<FirebaseAuthHandler>();
            builder.Services.AddTransient(x => FirestoreDb.Create("fordele"));
            builder.Services.AddTransient<UserFileService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}