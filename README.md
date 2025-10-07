## 📊 CSV → JSON Demo (ASP.NET Core API)

A minimal ASP.NET Core API that reads employee data from a CSV file and exposes it as JSON, with an option to import the data into an in-memory database.

---

## 🚀 Features

- **CSV to JSON**: Read `wwwroot/data/employees.csv` and return employees as JSON
- **Import to DB**: Persist employees to an in-memory EF Core database
- **Swagger UI**: Interactive API docs at `/swagger` in Development

---

## 📦 Tech Stack

- ASP.NET Core (Minimal hosting model)
- EF Core (InMemory)


## 📂 Project Structure

- `Program.cs` → App startup, DI, Swagger, routing
- `Controllers/EmployeesController.cs` → API endpoints
- `Services/CsvHelperService.cs` → CSV parsing and DB import logic
- `Data/AppDbContext.cs` → EF Core DbContext (in-memory)
- `Models/Employee.cs` → Employee model
- `wwwroot/data/employees.csv` → Sample CSV data source
- `appsettings.json` / `appsettings.Development.json` → configuration
- `CsvToJsonDemo.csproj` → project file

---

## 🛠 Prerequisites

- [.NET SDK 10.0](https://dotnet.microsoft.com/en-us/download/dotnet/10.0) (targets `net10.0`)
- Windows PowerShell, Bash, or any terminal
- Optional: Visual Studio 2022 or VS Code

---

## ▶️ Run the Project

Using the .NET CLI:

```bash
dotnet restore
dotnet run
```

## 🧪 Quick Tests

Replace the host and port with those shown in your console when the app starts.

Using curl (Bash):

```bash
curl http://localhost:5271/api/employees/import-csv
curl -X POST http://localhost:5271/api/employees/import-to-db
```

Using PowerShell:

```powershell
irm http://localhost:5271/api/employees/import-csv
irm -Method Post http://localhost:5271/api/employees/import-to-db
```


