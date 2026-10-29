
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using HotelManagementSystem.Data;

var builder = Host.CreateApplicationBuilder(args);

// Configure database connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// Build the application host
using var host = builder.Build();

Console.WriteLine("Hotel Management System");
Console.WriteLine("Application configuration completed successfully.");
Console.ReadKey();
