# Architecture

## System Overview

The application follows a **Layered Architecture** pattern with clear separation of concerns:

```
┌─────────────────────────────────────┐
│         Presentation Layer          │
│   Views (Razor), Controllers        │
└─────────────────────────────────────┘
            ↓
┌─────────────────────────────────────┐
│      Business Logic Layer           │
│   Services, Interfaces              │
└─────────────────────────────────────┘
            ↓
┌─────────────────────────────────────┐
│    Data Access Layer                │
│  EF Core, Dapper, Repositories      │
└─────────────────────────────────────┘
            ↓
┌─────────────────────────────────────┐
│       PostgreSQL Database           │
└─────────────────────────────────────┘
```

## Design Patterns

### 1. **MVC Pattern**

- **Model**: Domain entities (BlogPost, Project, User, etc.)
- **View**: Razor templates (.cshtml files)
- **Controller**: Request handlers that coordinate services and return views

### 2. **Repository Pattern**

Data access is abstracted through repositories:

```csharp
public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}
```

Repositories encapsulate database queries and reduce controller-level data access code.

### 3. **Unit of Work Pattern**

The UnitOfWork coordinates multiple repositories within a transaction:

```csharp
public interface IUnitOfWork
{
    IBlogRepository Blog { get; }
    IProjectRepository Projects { get; }
    Task<int> SaveChangesAsync();
}
```

Benefits:
- Single transaction scope
- Consistent save operations
- Simplified controller dependency injection

### 4. **Service Layer**

Business logic is isolated in services:

```csharp
public interface IBlogService
{
    Task<IEnumerable<BlogPostDto>> GetAllPostsAsync();
    Task<BlogPostDto?> GetPostByIdAsync(int id);
    Task<int> CreatePostAsync(CreateBlogPostDto dto);
    Task UpdatePostAsync(int id, UpdateBlogPostDto dto);
    Task DeletePostAsync(int id);
}
```

Services:
- Contain business rules
- Handle validation
- Coordinate repository operations
- Return DTOs instead of domain entities

### 5. **Dependency Injection**

The application uses ASP.NET Core's built-in DI container:

```csharp
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddSingleton<DbConnectionFactory>();
```

Lifetimes:
- **Singleton**: `DbConnectionFactory` (shared connection pool)
- **Scoped**: Services (one per HTTP request)
- **Transient**: Temporary objects

## Data Access Strategy

### EF Core + Dapper Hybrid Approach

The app uses **both** ORMs strategically:

**Entity Framework Core:**
- ✓ ASP.NET Identity tables
- ✓ DbContext for automatic migrations
- ✓ Automatic relationship tracking

**Dapper:**
- ✓ Custom complex queries
- ✓ High-performance data retrieval
- ✓ Direct SQL execution
- ✓ Used via `DbConnectionFactory`

Example:

```csharp
// EF Core - Identity user management
var user = await dbContext.Users.FindAsync(userId);

// Dapper - Complex blog queries
var connection = await _factory.CreateConnectionAsync();
var posts = await connection.QueryAsync<BlogPost>(
    "SELECT * FROM blog_posts WHERE status = @status",
    new { status = "published" }
);
```

## Authentication & Authorization

**ASP.NET Identity** handles authentication:

```csharp
builder.Services
    .AddIdentity<ApplicationUser, IdentityRole>(options => { ... })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
```

- User registration/login
- Password hashing
- Role-based authorization
- Token generation
- Cookie management

Authorization is enforced via attributes:

```csharp
[Authorize]
public async Task<IActionResult> CreatePost(CreateBlogPostDto dto)
{
    // Only authenticated users
}

[Authorize(Roles = "Admin")]
public async Task<IActionResult> DeletePost(int id)
{
    // Only admins
}
```

## Localization

**Bilingual Support** (English & Arabic):

1. **Resource Files** in `Resources/`:
   - `SharedResource.resx` (English)
   - `SharedResource.ar.resx` (Arabic)

2. **Culture Selection**:
   - Cookie-based persistence via `CultureController`
   - URL culture prefix (if configured)
   - Browser Accept-Language header

3. **In Views**:

   ```html
   @Html.DisplayNameFor(m => m.Title) <!-- Uses localized strings -->
   ```

4. **In Code**:

   ```csharp
   var localizer = _serviceProvider.GetRequiredService<IStringLocalizer<SharedResource>>();
   var message = localizer["WelcomeMessage"];
   ```

## Database Design

The application uses PostgreSQL with two connection methods:

1. **EF Core** for schema/migrations
2. **Dapper** for bulk operations

Connection setup:

```csharp
var connectionString = ConnectionHelper.ToNpgsqlConnectionString(
    Environment.GetEnvironmentVariable("DATABASE_URL")
);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString)
);
```

**Key Rule**: Always convert DATABASE_URL through `ConnectionHelper.ToNpgsqlConnectionString()` because Replit uses PostgreSQL URIs, not key-value strings.

## Request Flow

1. **HTTP Request** → Routing engine
2. **Controller** receives request
3. **Service** handles business logic
4. **Repository/UnitOfWork** accesses data via EF Core or Dapper
5. **Database** returns data
6. **Service** returns DTO
7. **View** renders response

Example flow for blog post retrieval:

```
GET /Blog/Post/5
  ↓
BlogController.GetPost(5)
  ↓
IBlogService.GetPostByIdAsync(5)
  ↓
IUnitOfWork.Blog.GetByIdAsync(5)
  ↓
Dapper Query: SELECT * FROM blog_posts WHERE id = @id
  ↓
PostgreSQL returns data
  ↓
BlogPostDto returned
  ↓
Post.cshtml rendered
  ↓
HTTP 200 Response
```

## Error Handling

The application uses:

- **Try-catch** in services for business exceptions
- **Exception middleware** in Program.cs for unhandled errors
- **Error views** (Error controller) for user-facing messages
- **Logging** for debugging

```csharp
[HttpPost]
public async Task<IActionResult> CreatePost(CreateBlogPostDto dto)
{
    try
    {
        var id = await _blogService.CreatePostAsync(dto);
        return RedirectToAction(nameof(GetPost), new { id });
    }
    catch (ValidationException ex)
    {
        ModelState.AddModelError("", ex.Message);
        return View();
    }
}
```

## Scalability Considerations

- **Connection pooling** via Npgsql
- **Async/await** for non-blocking operations
- **Caching opportunities** for frequently accessed data
- **Database indexing** on foreign keys and search fields
- **Pagination** for large result sets

## Security

- **ASP.NET Identity** for secure authentication
- **HTTPS** enforced in production
- **CSRF protection** via anti-forgery tokens
- **SQL injection prevention** via parameterized queries (both EF Core and Dapper)
- **Password requirements** configurable in Program.cs
