
using HotelManagementSystem.Data;
using HotelManagementSystem.Helpers;
using HotelManagementSystem.Menus;
using HotelManagementSystem.Repositories;
using HotelManagementSystem.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

// Read connection string from appsettings.json
string? connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");

// Check whether connection string exists
if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException(
        "DefaultConnection was not found. Check appsettings.json.");
}

// Configure database connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString)
);

// Register repositories
//var room=new RoomRepository();
builder.Services.AddScoped<RoomRepository>();
builder.Services.AddScoped<GuestRepository>();
builder.Services.AddScoped<BookingRepository>();
builder.Services.AddScoped<StaffRepository>();

// Register services
builder.Services.AddScoped<RoomService>();
builder.Services.AddScoped<GuestService>();
builder.Services.AddScoped<BookingService>();
builder.Services.AddScoped<StaffService>();

// Register menus
builder.Services.AddTransient<RoomMenu>();
builder.Services.AddTransient<GuestMenu>();
builder.Services.AddTransient<BookingMenu>();
builder.Services.AddTransient<StaffMenu>();
builder.Services.AddTransient<MainMenu>();

// Register helpers
builder.Services.AddSingleton<HotelSettings>();
builder.Services.AddTransient<DateRules>();
builder.Services.AddScoped<DatabaseHelper>();

// Build the application host
using var host = builder.Build();

// Check database connection
using (var scope = host.Services.CreateScope())
{
    var databaseHelper =
        scope.ServiceProvider.GetRequiredService<DatabaseHelper>();

    await databaseHelper.DisplayConnectionStatus();
}

// Run the main menu
var mainMenu =
    host.Services.GetRequiredService<MainMenu>();

await mainMenu.Run();
