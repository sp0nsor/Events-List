# Project Setup Instructions

## Backend Setup

To run the project, follow these steps:

1. **Update the Connection String**  
   Open the `appsettings.json` file and update the connection string:

   ```json
   "ConnectionStrings": {
       "EventsDbContext": "User ID=your_id;Password=your_password;Host=localhost;Port=your_port;Database=events-list;"
   }
   ```

2. **For PostgreSQL Users**  
   If you are using PostgreSQL, navigate to the project folder and run the following command in the console:

   ```bash
   dotnet ef database update -s .\Events.API -p .\Events.DataAccess
   ```

3. **For Other Databases**

   - Install the corresponding NuGet package for your database.
   - Update the database provider type in the `DataAccessExtensions` file, located in the `Events.DataAccess` project.
   - Recreate migrations with the following command:
     ```bash
     dotnet ef migrations add init -s .\Events.API -p .\Events.DataAccess
     ```
   - Update your database schema by running:
     ```bash
     dotnet ef database update -s .\Events.API -p .\Events.DataAccess
     ```

4. **Update the Connection String Again**  
   Ensure the connection string in the `appsettings.json` file is updated to reflect your database configuration.

5. **Run the Application**  
   Open the solution in your IDE and run the application.

## Frontend Setup

1. **Install Dependencies**

   ```bash
   npm install
   ```

2. **Run the Application**
   ```bash
   npm run dev
   ```
