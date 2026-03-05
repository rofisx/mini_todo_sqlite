# Mini Todo API - SQLite

Aplikasi REST API sederhana untuk mengelola todo list dengan menggunakan ASP.NET Core dan SQLite.

## Tech Stack

- **Framework**: ASP.NET Core 9.0
- **Database**: SQLite
- **ORM**: Entity Framework Core
- **Language**: C#

## Deskripsi Project

Mini Todo API adalah aplikasi pembelajaran untuk demonstrasi pembuatan REST API sederhana menggunakan ASP.NET Core dengan database SQLite. Aplikasi ini menyediakan endpoint untuk CRUD (Create, Read, Update, Delete) todo items.

## Struktur Project

```
mini_todo_sqlite/
 Controllers/
    TodosController.cs              # API endpoints
 Data/
    AppDbContext.cs                 # EF Core DbContext
 Migrations/
    20260107144240_InitialCreate.cs
    20260107144240_InitialCreate.Designer.cs
    AppDbContextModelSnapshot.cs
 Models/
    Todo.cs                         # Todo entity model
 Properties/
    launchSettings.json             # Launch configuration
 Program.cs                          # Application entry point
 appsettings.json                    # App configuration
 appsettings.Development.json        # Development settings
 todoapi_sqllite.csproj              # Project file
 todoapi_sqllite.http                # HTTP test requests
 todoapi_sqllite.sln                 # Solution file
 .gitignore                          # Git ignore rules
```

## Requirements

- [.NET SDK 9.0](https://dotnet.microsoft.com/download) atau lebih tinggi
- SQLite (otomatis disertakan)

## Quick Start

### 1. Clone Repository

```bash
git clone <repository-url>
cd mini_todo_sqlite
```

### 2. Restore Dependencies

```bash
dotnet restore
```

### 3. Setup Development Configuration

Buat file `appsettings.Development.json`:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning"
    }
  }
}
```

### 4. Build Project

```bash
dotnet build
```

### 5. Create & Update Database

```bash
dotnet ef database update
```

### 6. Run Application

```bash
dotnet run
```

Aplikasi akan berjalan di: `http://localhost:5000` atau `https://localhost:5001`

## API Endpoints

| Method | Endpoint          | Deskripsi                 |
| ------ | ----------------- | ------------------------- |
| GET    | `/api/todos`      | Ambil semua todo          |
| GET    | `/api/todos/{id}` | Ambil todo berdasarkan ID |
| POST   | `/api/todos`      | Buat todo baru            |
| PUT    | `/api/todos/{id}` | Update todo               |
| DELETE | `/api/todos/{id}` | Hapus todo                |

## Database

Database SQLite otomatis dibuat dengan nama `todo.db`:

- `todo.db` - Database file utama
- `todo.db-shm` - Shared memory file (WAL)
- `todo.db-wal` - Write-Ahead Logging file

Reset database jika diperlukan:

```bash
dotnet ef database drop
dotnet ef database update
```

## Testing API

Gunakan file `todoapi_sqllite.http` untuk testing dengan REST Client extension di VS Code:

1. Install extension [REST Client](https://marketplace.visualstudio.com/items?itemName=humao.rest-client)
2. Buka file `todoapi_sqllite.http`
3. Klik tombol "Send Request" untuk mengirim request

## File Penting

| File                           | Fungsi                              |
| ------------------------------ | ----------------------------------- |
| `Program.cs`                   | Konfigurasi aplikasi dan middleware |
| `appsettings.json`             | Konfigurasi umum                    |
| `appsettings.Development.json` | Konfigurasi development             |
| `.gitignore`                   | File yang diabaikan git             |

## Development Commands

```bash
# Build project
dotnet build

# Run dengan watch mode
dotnet watch run

# Create migration
dotnet ef migrations add <MigrationName>

# View database
dotnet ef dbcontext info

# Remove last migration
dotnet ef migrations remove
```

## Resources

- [ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core)
- [Entity Framework Core](https://docs.microsoft.com/ef/core)
- [SQLite Documentation](https://www.sqlite.org)
- [Microsoft Learn - ASP.NET Core](https://learn.microsoft.com/aspnet/core)

## License

MIT License

## 👤 Author

- **Rofi** - [LinkedIn](https://linkedin.com/in/syukron-isrofi)
