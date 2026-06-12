# Mostafa Said Portfolio

A full-featured portfolio website built with **ASP.NET Core 9 MVC** and **PostgreSQL**, showcasing projects, blog posts, testimonials, and events.

## Quick Start

```bash
git clone https://github.com/Mostafa-SAID7/MS-port-MVC
cd MS-port-MVC/MostafaSaidPortfolio
dotnet restore
dotnet run
```

Access the app at `http://localhost:5000`

## Documentation

Complete documentation is available in the [`docs/`](./docs/) folder:

- **[Getting Started](./docs/GETTING_STARTED.md)** - Setup and installation
- **[Project Structure](./docs/PROJECT_STRUCTURE.md)** - Directory organization
- **[Architecture](./docs/ARCHITECTURE.md)** - Design patterns and system design
- **[Database](./docs/DATABASE.md)** - PostgreSQL schema and migrations
- **[Features](./docs/FEATURES.md)** - Core features overview
- **[API Reference](./docs/API_REFERENCE.md)** - REST API endpoints
- **[Development Guide](./docs/DEVELOPMENT.md)** - Contributing and best practices

## Key Features

✓ **Blog System** - Categories, tags, comments  
✓ **Project Showcase** - Portfolio projects with galleries  
✓ **Testimonials** - User reviews and ratings  
✓ **Events Management** - Upcoming events and scheduling  
✓ **Contact Forms** - Email notifications  
✓ **Newsletter** - Subscriber management  
✓ **User Authentication** - Secure login with ASP.NET Identity  
✓ **Admin Dashboard** - Content management  
✓ **Bilingual Support** - English & Arabic localization  
✓ **Search** - Full-text blog search  
✓ **REST API** - Public API endpoints  

## Technology Stack

| Component | Technology |
|-----------|-----------|
| Framework | ASP.NET Core 9 MVC |
| Database | PostgreSQL 14+ |
| ORM | Entity Framework Core 9 + Dapper 2.1 |
| Authentication | ASP.NET Identity |
| Templating | Razor Views |
| Frontend | HTML5, CSS3, Bootstrap |

## Prerequisites

- **.NET 9 SDK** - [Download](https://dotnet.microsoft.com/download/dotnet/9.0)
- **PostgreSQL 14+** - [Download](https://www.postgresql.org/download/)
- **Visual Studio 2022** or **VS Code**

## Installation

See [Getting Started Guide](./docs/GETTING_STARTED.md) for detailed setup instructions.

## Project Structure

```
MS-port-MVC/
├── MostafaSaidPortfolio/          # Main application
│   ├── Controllers/               # MVC controllers
│   ├── Models/                    # Domain entities
│   ├── Services/                  # Business logic
│   ├── Data/                      # Database access
│   ├── Views/                     # Razor templates
│   └── wwwroot/                   # Static files
├── docs/                          # Complete documentation
└── README.md
```

See [Project Structure Guide](./docs/PROJECT_STRUCTURE.md) for full details.

## Development

### Build

```bash
dotnet build
```

### Run

```bash
dotnet run
```

### Hot Reload

```bash
dotnet watch run
```

### Database Migrations

```bash
dotnet ef migrations add MigrationName
dotnet ef database update
```

See [Development Guide](./docs/DEVELOPMENT.md) for more information.

## API

The application includes REST API endpoints for programmatic access:

```
GET  /api/blog              - List blog posts
GET  /api/blog/{id}         - Get single post
POST /api/blog              - Create post (auth required)
GET  /api/projects          - List projects
GET  /api/testimonials      - List testimonials
GET  /api/events            - List events
GET  /api/search            - Search content
```

See [API Reference](./docs/API_REFERENCE.md) for complete endpoint documentation.

## Configuration

### Database Connection

Set via environment variable:

```bash
export DATABASE_URL="postgresql://user:password@localhost:5432/portfolio_db"
```

Or in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=portfolio_db;Username=user;Password=password"
  }
}
```

### Email Settings

Configure SMTP in `appsettings.json`:

```json
{
  "EmailSettings": {
    "SmtpServer": "smtp.gmail.com",
    "Port": 587,
    "SenderEmail": "your-email@gmail.com"
  }
}
```

## Architecture

The application follows a **Layered Architecture** with:

- **Presentation Layer**: Controllers and Views
- **Business Logic Layer**: Services
- **Data Access Layer**: Repositories and EF Core/Dapper
- **Database**: PostgreSQL

See [Architecture Guide](./docs/ARCHITECTURE.md) for design patterns and system design.

## Security

- **HTTPS** enforced in production
- **ASP.NET Identity** for authentication
- **CSRF Protection** on all forms
- **SQL Injection Prevention** via parameterized queries
- **Password Hashing** via bcrypt
- **Authorization** with role-based access control

## Performance

- **Async/Await** for all I/O operations
- **Connection Pooling** for database
- **Caching** for frequently accessed data
- **Pagination** for large datasets
- **Dapper** for complex query optimization

## Localization

The app supports **English** and **Arabic** with automatic language switching based on:

- Browser language preference
- Cookie-stored language selection
- URL culture parameter

## License

This project is open source and available under the MIT License.

## Author

**Mostafa Said** - [GitHub](https://github.com/Mostafa-SAID7)

## Support

For questions, issues, or contributions:

1. Check the [Documentation](./docs/)
2. Open an [Issue](https://github.com/Mostafa-SAID7/MS-port-MVC/issues)
3. Submit a [Pull Request](https://github.com/Mostafa-SAID7/MS-port-MVC/pulls)

## Changelog

See [Git Commit History](https://github.com/Mostafa-SAID7/MS-port-MVC/commits) for project changes.