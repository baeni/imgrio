using Firebase.Auth;
using Google.Cloud.Firestore;
using Imgrio.Blazor.Backend.Models;
using Imgrio.Blazor.Backend.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Imgrio.Blazor
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
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.Name = "imgrio.Auth";
                    options.ExpireTimeSpan = TimeSpan.FromDays(7);
                    options.SlidingExpiration = true;
                    options.LoginPath = "/u/sign-in";
                    options.LogoutPath = "/u/sign-out";
                });
            builder.Services.AddSingleton<UserState>();
            builder.Services.AddScoped<UserAuthService>();
            builder.Services.AddSingleton<IFirebaseAuthProvider>(_ => new FirebaseAuthProvider(new FirebaseConfig("AIzaSyC-a7ssy-0Wx5Vf1OVvu1KtSO5MJ8t-CD0")));
            builder.Services.AddTransient(_ => FirestoreDb.Create("imgrio"));
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