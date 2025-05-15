🏬 SportsStore MVC Project – Setup Guide
This guide walks you through the process of cloning the SportsStore ASP.NET MVC project from GitHub and running it in Visual Studio 2022, using LocalDB as the database engine.

🧰 Prerequisites
Before you begin, ensure the following are installed:

✅ Visual Studio 2022 (with ASP.NET and web development workload)

✅ Git

✅ SQL Server Express LocalDB (comes with Visual Studio)

✅ NuGet package manager (comes with Visual Studio)

📥 Step 1: Clone the Repository
1. Open a terminal or Git Bash.
2. Clone the repository using the URL:
 - git clone https://github.com/ASENDIENTEKevinVance/SportsStore.git
3. Navigate to the project folder:
 - cd SportsStore

🛠️ Step 2: Open the Project in Visual Studio 2022
1. Launch Visual Studio 2022.
2. Click File > Open > Project/Solution.
3. Navigate to the SportsStore folder and select the .sln file (e.g., SportsStore.sln).
4. Click Open.

🔄 Step 3: Restore NuGet Packages
1. Go to Tools > NuGet Package Manager > Manage NuGet Packages for Solution.
2. Click Restore (or use the Package Manager Console):
 - Update-Package -reinstall

🛢️ Step 4: Set Up LocalDB
1. Open Web.config or appsettings.json and verify the connection string. It should look like:
 - <connectionStrings>
    <add name="SportsStoreDb" 
       connectionString="Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SportsStore;Integrated Security=True;" 
       providerName="System.Data.SqlClient" />
  </connectionStrings>
2. Open the Package Manager Console (Tools > NuGet Package Manager > Package Manager Console).
3. Run the following to create the database using migrations:
 - Update-Database

▶️ Step 5: Run the Project
1. Set the project as Startup Project (Right-click the project in Solution Explorer > Set as Startup Project).
2. Press F5 or click Start Debugging to run the app.


🧪 Troubleshooting
LocalDB Not Found?
  - Open Command Prompt and run: sqllocaldb i
  - If not installed, repair or install SQL Server Express.
Migrations Errors?
  - Ensure Entity Framework is installed:
    - Install-Package EntityFramework
Port Conflicts?
  - In launchSettings.json, change the application URL port if needed.
