# Project Structure

## Directory Layout

```
MS-port-MVC/
├── MostafaSaidPortfolio/          # Main ASP.NET Core MVC application
│   ├── Areas/                     # Area routing (Admin panel)
│   │   └── Admin/
│   ├── Components/                # View components and tag helpers
│   │   ├── Razor/
│   │   ├── TagHelpers/
│   │   └── ViewComponents/
│   ├── Controllers/               # MVC controllers
│   │   ├── Api/                   # API endpoints
│   │   ├── AccountController.cs
│   │   ├── BlogController.cs
│   │   ├── ProjectsController.cs
│   │   └── ... (other controllers)
│   ├── Data/                      # Data access layer
│   │   ├── ApplicationDbContext.cs
│   │   ├── ConnectionHelper.cs    # URI conversion helper
│   │   ├── DatabaseInitializer.cs # Seed data
│   │   ├── DbConnectionFactory.cs # Dapper connections
│   │   ├── Repositories/          # Repository pattern
│   │   └── UnitOfWork/            # Unit of Work pattern
│   ├── Models/                    # Domain models
│   │   ├── BlogPost.cs
│   │   ├── Project.cs
│   │   ├── Comment.cs
│   │   └── ... (other models)
│   ├── Services/                  # Business logic layer
│   │   ├── Interfaces/            # Service contracts
│   │   └── Implementations/       # Service implementations
│   ├── Views/                     # Razor view templates
│   │   ├── Account/
│   │   ├── Blog/
│   │   ├── Home/
│   │   ├── Projects/
│   │   └── Shared/
│   ├── ViewModels/                # View-specific models
│   ├── Resources/                 # Localization resources (.resx)
│   ├── wwwroot/                   # Static files
│   │   ├── css/
│   │   ├── js/
│   │   └── lib/
│   ├── Program.cs                 # Application entry point
│   ├── appsettings.json           # Configuration
│   └── MostafaSaidPortfolio.csproj
├── server/                        # TypeScript/Node backend (supplementary)
│   └── db.ts                      # Drizzle ORM setup
├── docs/                          # Documentation (this folder)
└── README.md
```

## Key Directories

### Controllers (`Controllers/`)

Handles HTTP requests and routing:

- **AccountController** - User authentication and profile
- **BlogController** - Blog listing and posts
- **ProjectsController** - Project showcase
- **ContactController** - Contact form submissions
- **TestimonialsController** - Testimonial display
- **EventsController** - Event management
- **Api/** - RESTful API endpoints

### Models (`Models/`)

Domain entities representing database tables:

- `ApplicationUser` - Identity user (extends IdentityUser)
- `BlogPost` - Blog articles
- `Project` - Portfolio projects
- `Comment` - Blog comments
- `Testimonial` - User testimonials
- `Event` - Event listings
- `Category`, `Tag` - Blog organization
- `ContactMessage` - Form submissions
- `NewsletterSubscriber` - Newsletter signups

### Services (`Services/`)

Business logic abstraction layer:

**Interfaces:**
- `IBlogService` - Blog operations
- `IProjectService` - Project operations
- `IEmailService` - Email sending
- `ITestimonialService` - Testimonial operations
- `IEventsService` - Event operations
- `INewsletterService` - Newsletter management
- `ILocalizationService` - Localization helpers

**Implementations:** Corresponding implementations with Dapper queries or EF Core operations.

### Data (`Data/`)

Database access and initialization:

- **ApplicationDbContext** - EF Core DbContext for Identity
- **ConnectionHelper** - Converts PostgreSQL URIs to Npgsql strings
- **DbConnectionFactory** - Creates Dapper IDbConnection instances
- **DatabaseInitializer** - Seed data and schema setup
- **Repositories/** - Data access patterns
- **UnitOfWork/** - Transaction coordination

### Views (`Views/`)

Razor templates for each controller:

```
Views/
├── Account/    - Login, register
├── Blog/       - Blog listing, post details
├── Home/       - Homepage
├── Projects/   - Project gallery
├── Shared/     - Layouts, partials
└── Search/     - Search results
```

### Static Files (`wwwroot/`)

Client-side resources:

```
wwwroot/
├── css/     - Stylesheets
├── js/      - JavaScript
├── lib/     - Third-party libraries (Bootstrap, jQuery, etc.)
└── favicon.ico
```

### Resources (`Resources/`)

Localization files for EN/AR translation:

- `SharedResource.resx` - English strings
- `SharedResource.ar.resx` - Arabic strings

### Areas (`Areas/`)

Admin dashboard in its own routing area:

```
Areas/Admin/
├── Controllers/
├── Views/
└── Models/
```

## File Naming Conventions

- **Controllers**: `*Controller.cs` (e.g., `BlogController.cs`)
- **Models**: PascalCase (e.g., `BlogPost.cs`)
- **Interfaces**: `I*` prefix (e.g., `IBlogService.cs`)
- **Views**: Match controller action (e.g., `Views/Blog/Index.cshtml`)
- **Resources**: `.resx` XML format (Visual Studio managed)

## Configuration Files

| File | Purpose |
|------|---------|
| `Program.cs` | Application startup & DI configuration |
| `appsettings.json` | App settings & secrets |
| `appsettings.Development.json` | Development overrides |
| `launchSettings.json` | Launch profiles & ports |
| `.csproj` | Project file with NuGet dependencies |

## Documentation Files

```
docs/
├── README.md                 - Documentation home
├── GETTING_STARTED.md        - Setup guide
├── PROJECT_STRUCTURE.md      - This file
├── ARCHITECTURE.md           - Design patterns & system architecture
├── DATABASE.md               - Database schema & migrations
├── FEATURES.md               - Feature descriptions
├── API_REFERENCE.md          - API endpoints
└── DEVELOPMENT.md            - Development guide & best practices
```
