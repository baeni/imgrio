using imgrio_api.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace imgrio_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
            {
                policy.SetIsOriginAllowed(origin => origin.Equals("imgrio.com") || origin.EndsWith(".imgrio.com") || origin.Contains(""))
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            }));

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    builder.Configuration.Bind("AzureAd", options);
                    options.Authority = $"{builder.Configuration["AzureAd:Instance"]}{builder.Configuration["AzureAd:TenantId"]}/v2.0";
                    
                    options.TokenValidationParameters.ValidateIssuer = false;
                })
                .AddJwtBearer("FirebaseJwtPolicy", options =>
                {
                    options.IncludeErrorDetails = true;
                    options.Authority = "https://securetoken.google.com/imgrio-b1ddc";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = "https://securetoken.google.com/imgrio-b1ddc",

                        ValidateAudience = true,
                        ValidAudience = "imgrio-b1ddc",

                        ValidateLifetime = true
                    };
                })
                .AddJwtBearer("PermanentJwtPolicy", options =>
                {
                    options.IncludeErrorDetails = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],

                        ValidateAudience = true,
                        ValidAudience = builder.Configuration["Jwt:Audience"],

                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
                    };
                });

            var connectionString = builder.Configuration.GetConnectionString("Postgres");
            builder.Services.AddDbContext<ImgrioDbContext>(options => options.UseNpgsql(connectionString));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}