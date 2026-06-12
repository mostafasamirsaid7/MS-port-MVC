# Getting Started

## Prerequisites

- **.NET 9 SDK** - [Download](https://dotnet.microsoft.com/download/dotnet/9.0)
- **PostgreSQL 14+** - [Download](https://www.postgresql.org/download/)
- **Visual Studio 2022** or **VS Code** with C# extension

## Installation

### 1. Clone the Repository

```bash
git clone https://github.com/Mostafa-SAID7/MS-port-MVC
cd MS-port-MVC
```

### 2. Setup Database

Create a PostgreSQL database:

```sql
CREATE DATABASE portfolio_db;
```

### 3. Configure Connection String

Set the `DATABASE_URL` environment variable or update `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "postgresql://user:password@localhost:5432/portfolio_db"
  }
}
```

**Important**: The app automatically converts Replit's URI format using `ConnectionHelper.ToNpgsqlConnectionString()`.

### 4. Install Dependencies

```bash
cd MostafaSaidPortfolio
dotnet restore
```

### 5. Build the Project

```bash
dotnet build
```

### 6. Initialize Database

The database schema and seed data are created automatically when the app starts:

```bash
dotnet run
```

The app will:
- Create the Identity schema
- Initialize custom tables
- Seed sample data

## Running the Application

### Development Mode

```bash
dotnet run
```

Access the app at: `http://localhost:5000`

### Using Visual Studio

1. Open `MostafaSaidPortfolio.sln`
2. Press `F5` or click **Start Debugging**
3. The app will launch in your default browser

## Environment Configuration

### Development Settings

Edit `appsettings.Development.json` for local overrides:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Debug"
    }
  }
}
```

### Email Configuration

Update email settings in `appsettings.json`:

```json
{
  "EmailSettings": {
    "SmtpServer": "your-smtp-server.com",
    "Port": 587,
    "SenderName": "Portfolio",
    "SenderEmail": "sender@example.com",
    "Username": "your-email",
    "Password": "your-password"
  }
}
```

## Supported Cultures

The app supports two cultures:

- **en** - English (default)
- **ar** - Arabic

Switch languages via the `/Culture/SetCulture` endpoint or the UI selector.

## Next Steps

- Explore [Project Structure](./PROJECT_STRUCTURE.md)
- Review [Architecture](./ARCHITECTURE.md)
- Check [Features](./FEATURES.md)

## Troubleshooting

### Database Connection Error

**Issue**: `KeyNotFoundException` on startup

**Solution**: Ensure `DATABASE_URL` is properly formatted. The app expects PostgreSQL URIs which are automatically converted.

### Port Already in Use

**Issue**: `OSError: Address already in use`

**Solution**: Change the port in `launchSettings.json` or run:

```bash
dotnet run --urls "http://localhost:5001"
```

### Missing Dependencies

**Issue**: Build fails with missing packages

**Solution**: Run `dotnet restore` and ensure .NET 9 SDK is installed.
