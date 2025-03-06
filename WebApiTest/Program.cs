
using WebApiTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApiTest.Data;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using WebApiTest.Areas.Identity.Data;

namespace WebApiTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // link up the database 
            builder.Services.AddDbContext<WebApiTestContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("WebApiTestContext") ?? throw new InvalidOperationException("Connection string 'WebApiTestContext' not found.")));

            // links up identity, and links it to the database
            builder.Services.AddDefaultIdentity<BlogUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<WebApiTestContext>();

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.WriteIndented = true;
            });


            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            // app.MapRazorPosts(); // Comment out or remove this line as it is causing the error



            app.Run();
        }
    }
}