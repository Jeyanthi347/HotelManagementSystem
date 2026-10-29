🏨 Hotel Management System – Console Application

🚀 Overview

Hotel Management System is a console-based application developed using C#, .NET 10, Entity Framework Core, and SQL Server.

The application manages hotel rooms, guests, bookings, and staff. It follows a layered architecture that separates models, data access, repositories, services, menus, and helper classes for better code organization and maintainability.


🧠 Features

🔹 Room Management

- View all rooms
- Add new rooms
- Update room details
- Delete rooms
- Track room availability
- Manage room types and prices per night

  
🔹 Guest Management

- View all guests
- Add new guests
- Update guest details
- Delete guests
- Store guest names, email addresses, and phone numbers

🔹 Booking Management

- View all bookings
- Create new bookings
- Update booking details
- Delete bookings
- Associate bookings with guests and rooms
- Validate guest and room IDs
- Validate check-in and check-out dates
- Track booking status

🔹 Staff Management

- View all staff members
- Add new staff members
- Update staff details
- Delete staff members
- Manage staff roles, phone numbers, and salaries

🔹 Database & Architecture

- Entity Framework Core integration
- SQL Server database connectivity
- Code-first database migrations
- Repository pattern for database operations
- Service layer for business logic
- Dependency injection
- Foreign key relationships between bookings, guests, and rooms
- Helper classes for common operations


🛠️ Tech Stack

🔹 Backend

- C#
- .NET 10
- Entity Framework Core 10
- Microsoft.Extensions.Hosting
- Microsoft.Extensions.DependencyInjection

🔹 Database

- Microsoft SQL Server
- SQL Server Management Studio (SSMS)
- Entity Framework Core Code First Migrations

🔹 Development Tools

- Visual Studio
- Git
- GitHub


📂 Project Structure

HotelManagementSystem/
│
├── Models/
│   ├── Room.cs
│   ├── Guest.cs
│   ├── Booking.cs
│   └── Staff.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── Repositories/
│   ├── RoomRepository.cs
│   ├── GuestRepository.cs
│   ├── BookingRepository.cs
│   └── StaffRepository.cs
│
├── Services/
│   ├── RoomService.cs
│   ├── GuestService.cs
│   ├── BookingService.cs
│   └── StaffService.cs
│
├── Menus/
│   ├── MainMenu.cs
│   ├── RoomMenu.cs
│   ├── GuestMenu.cs
│   ├── BookingMenu.cs
│   └── StaffMenu.cs
│
├── Helpers/
│   ├── HotelSettings.cs
│   ├── DateRules.cs
│   └── DatabaseHelper.cs
│
├── Migrations/
├── Program.cs
├── appsettings.json
└── HotelManagementSystem.csproj


⚙️ Setup Instructions

🔹 Prerequisites

Make sure the following tools are installed:

- .NET 10 SDK
- Visual Studio
- SQL Server Express
- SQL Server Management Studio (SSMS)
- Git

🔹 Step 1: Clone the Repository

```bash
git clone <your-github-repository-url>
cd HotelManagementSystem
```

Open the project in Visual Studio.

🔹 Step 2: Configure the Database

Open `appsettings.json` and configure the SQL Server connection string:

Update the server name if your SQL Server instance uses a different name.

🔹 Step 3: Restore Dependencies

Open a terminal in the directory containing `HotelManagementSystem.csproj` and run:

```bash
dotnet restore
```

🔹 Step 4: Install Entity Framework Core Tools

If the EF Core command-line tool is not installed, run:


dotnet tool install --global dotnet-ef --version 10.0.14


If it is already installed, update it when necessary:


dotnet tool update --global dotnet-ef --version 10.0.14

🔹 Step 5: Create and Update the Database

Apply the existing migration to create the database tables:


dotnet ef database update

If no migration exists yet, create one first:


dotnet ef migrations add InitialCreate
dotnet ef database update

🔹 Step 6: Build and Run the Application
dotnet build
dotnet run

The Hotel Management System main menu will appear in the console.


🗄️ Database Tables

| Table | Description |
|---|---|
| `Rooms` | Stores room numbers, types, prices, and availability |
| `Guests` | Stores guest names, email addresses, and phone numbers |
| `Bookings` | Stores guest IDs, room IDs, check-in dates, check-out dates, and booking status |
| `Staff` | Stores staff names, roles, phone numbers, and salaries |
| `__EFMigrationsHistory` | Tracks applied Entity Framework Core migrations |

The `Bookings` table has foreign key relationships with `Guests` and `Rooms`.

 🔄 Application Architecture


Console Menus
     |
     v
Services Layer
     |
     v
Repositories Layer
     |
     v
AppDbContext (EF Core)
     |
     v
SQL Server Database


- **Models:** Define the application's data entities.
- **Data:** Configures the EF Core database context and entity relationships.
- **Repositories:** Handle create, read, update, and delete operations.
- **Services:** Apply business rules and validations.
- **Menus:** Provide console-based interaction for users.
- **Helpers:** Provide reusable utility functions and configuration-related functionality.



🚀 Future Enhancements

- User login and authentication
- Role-based access for administrators and staff
- Search and filter rooms
- Check room availability for specific date ranges
- Prevent overlapping bookings
- Calculate booking costs based on the number of nights
- Booking cancellation and checkout functionality
- Payment management
- Booking reports and revenue summaries
- Convert the console application into a web application
- Add a responsive frontend using HTML, CSS, and JavaScript



💯 Learning Outcomes

- C# and .NET application development
- Entity Framework Core and database migrations
- SQL Server database integration
- CRUD operations
- Repository and service layer architecture
- Dependency injection
- Foreign key relationships
- Console menu design
- Exception handling and business rule validation
- Git and GitHub version control

