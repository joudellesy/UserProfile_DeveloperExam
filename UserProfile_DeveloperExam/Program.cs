using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using UserProfile_DeveloperExam.Controllers;
using UserProfile_DeveloperExam.DBContext;
using UserProfile_DeveloperExam.Interface;
using UserProfile_DeveloperExam.Repositories;
using UserProfile_DeveloperExam.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        // Configure logging
        builder.Logging.ClearProviders();  // Clear default providers (optional)
        builder.Logging.AddConsole();      // Add console logging
        builder.Logging.SetMinimumLevel(LogLevel.Information); // Set minimum log level
        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddMvc();
        builder.Services.AddDbContext<UserProfileDBContext>(options =>
            options.UseSqlServer(new SqlConnection(builder.Configuration.GetConnectionString("SqlServer")))
            );
        //builder.Services.AddTransient<IUserProfileRepositoryInterface, UserProfileService>();
        //builder.Services.AddTransient<IUserProfileRepositoryInterface, UserProfileRepository>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}