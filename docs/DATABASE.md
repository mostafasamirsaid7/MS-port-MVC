# Database

## Overview

The application uses **PostgreSQL 14+** as the primary database. It's initialized automatically on first run with both EF Core (Identity tables) and custom tables for domain entities.

## Connection Setup

### Environment Variable

Set `DATABASE_URL` to your PostgreSQL connection:

```bash
# Replit format (automatically converted)
DATABASE_URL=postgresql://user:password@host:5432/dbname

# Connection string format (used directly)
DefaultConnection=Host=localhost;Port=5432;Database=portfolio_db;Username=user;Password=password
```

### Automatic Conversion

The `ConnectionHelper` class converts Replit's URI format to Npgsql's key-value format:

```csharp
public static string ToNpgsqlConnectionString(string rawConnectionString)
{
    var uri = new Uri(rawConnectionString);
    return $"Host={uri.Host};Port={uri.Port};Database={uri.LocalPath.TrimStart('/')};Username={uri.UserInfo.Split(':')[0]};Password={uri.UserInfo.Split(':')[1]}";
}
```

This is called in `Program.cs` and `DbConnectionFactory`.

## Database Initialization

On first run, the application:

1. Creates Identity schema (users, roles, claims tables)
2. Creates custom tables via `DatabaseInitializer`
3. Seeds sample data
4. Establishes foreign key relationships

```csharp
// Program.cs startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.EnsureCreated();

    var factory = scope.ServiceProvider.GetRequiredService<DbConnectionFactory>();
    await DatabaseInitializer.InitializeAsync(factory);
}
```

## Schema

### Identity Tables (EF Core managed)

```sql
-- Users
AspNetUsers (Id, UserName, Email, PasswordHash, ...)

-- Roles
AspNetRoles (Id, Name, NormalizedName)

-- User-Role mappings
AspNetUserRoles (UserId, RoleId)

-- Claims
AspNetUserClaims (Id, UserId, ClaimType, ClaimValue)

-- Logins
AspNetUserLogins (LoginProvider, ProviderKey, UserId, ...)

-- Tokens
AspNetUserTokens (UserId, LoginProvider, Name, Value)
```

### Custom Tables (via Dapper/DatabaseInitializer)

| Table | Purpose | Key Fields |
|-------|---------|-----------|
| `blog_posts` | Blog articles | id, title, slug, content, user_id, status, created_at |
| `comments` | Blog comments | id, post_id, user_id, content, created_at |
| `categories` | Blog categories | id, name, slug, description |
| `tags` | Blog tags | id, name, slug |
| `post_tags` | Post-tag mapping | post_id, tag_id |
| `projects` | Portfolio projects | id, title, slug, description, technologies, link, image_url |
| `testimonials` | User testimonials | id, author_name, position, content, rating, image_url |
| `events` | Event listings | id, title, description, date, location, status |
| `contact_messages` | Contact form submissions | id, name, email, subject, message, created_at, status |
| `newsletter_subscribers` | Newsletter subscriptions | id, email, subscribed_at, is_active |

## Key Relationships

```
ApplicationUser (1) ──── (N) BlogPost
ApplicationUser (1) ──── (N) Comment
ApplicationUser (1) ──── (N) ContactMessage

BlogPost (1) ──── (N) Comment
BlogPost (1) ──── (N) Tag (M2M via post_tags)
BlogPost (1) ──── (1) Category
```

## Data Access Methods

### EF Core (Identity)

```csharp
var user = await dbContext.Users.FindAsync(userId);
var users = await dbContext.Users.ToListAsync();
dbContext.Users.Add(newUser);
await dbContext.SaveChangesAsync();
```

### Dapper (Custom queries)

```csharp
var connection = await _factory.CreateConnectionAsync();

// Query
var posts = await connection.QueryAsync<BlogPost>(
    "SELECT * FROM blog_posts WHERE category_id = @categoryId",
    new { categoryId = 1 }
);

// Execute
await connection.ExecuteAsync(
    "UPDATE blog_posts SET status = @status WHERE id = @id",
    new { status = "published", id = postId }
);
```

## Seed Data

The `DatabaseInitializer` seeds:

- Sample blog posts with categories and tags
- Portfolio projects
- Testimonials
- Sample events
- Newsletter subscribers

Seed data uses parameterized Dapper inserts to prevent SQL injection:

```csharp
await connection.ExecuteAsync(
    @"INSERT INTO blog_posts (title, content, user_id, status, created_at)
      VALUES (@title, @content, @userId, @status, @createdAt)",
    new
    {
        title = "First Post",
        content = "Blog content here",
        userId = 1,
        status = "published",
        createdAt = DateTime.UtcNow
    }
);
```

## Important Rules

### PostgreSQL URI Conversion

**Never** pass raw Replit DATABASE_URL directly to EF Core or Dapper:

```csharp
// ❌ Wrong
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(rawUri)  // Fails with KeyNotFoundException
);

// ✓ Correct
var connectionString = ConnectionHelper.ToNpgsqlConnectionString(rawUri);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString)
);
```

### Blog Content with Markdown

Never embed markdown code fences directly in C# string literals:

```csharp
// ❌ Wrong - causes CS1056 error
var content = @"
```sql
SELECT * FROM users;
```
";

// ✓ Correct - build as string variable
string sqlContent = "```sql\nSELECT * FROM users;\n```";
await connection.ExecuteAsync(
    "INSERT INTO blog_posts (content) VALUES (@content)",
    new { content = sqlContent }
);
```

## Backup & Restore

### Backup PostgreSQL

```bash
pg_dump -U user -d portfolio_db > backup.sql
```

### Restore PostgreSQL

```bash
psql -U user -d portfolio_db < backup.sql
```

## Migrations

The application uses **code-first** with EF Core. To add migrations:

```bash
cd MostafaSaidPortfolio

# Add a new migration
dotnet ef migrations add AddNewFeature

# Apply migrations
dotnet ef database update

# Remove last migration
dotnet ef migrations remove
```

Migrations are stored in the `Data/Migrations` folder (if enabled).

## Performance Considerations

- **Indexes**: Foreign keys are auto-indexed; add indexes on frequently searched columns
- **Connection Pooling**: Npgsql connection pooling is enabled by default
- **Async Queries**: All queries use async/await to prevent blocking
- **Dapper**: Use for complex queries and bulk operations
- **EF Core**: Use for entity relationships and transactions

## Troubleshooting

### Connection Error: KeyNotFoundException

**Cause**: Raw DATABASE_URL not converted through `ConnectionHelper`

**Fix**:
```csharp
var connectionString = ConnectionHelper.ToNpgsqlConnectionString(
    Environment.GetEnvironmentVariable("DATABASE_URL")
);
```

### Foreign Key Constraint Errors

**Cause**: Deleting records that have dependent data

**Solution**: Use cascading deletes in migrations or delete dependent records first.

### Slow Queries

**Solution**: 
- Add indexes on `WHERE` clause columns
- Use Dapper for complex queries
- Enable query logging in development

```csharp
.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
```

### Database File Locked (SQLite)

This project uses PostgreSQL, not SQLite, so file locking isn't an issue. Ensure PostgreSQL server is running.
