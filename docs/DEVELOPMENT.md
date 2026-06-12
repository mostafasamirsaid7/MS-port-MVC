# Development Guide

## Development Workflow

### 1. Local Setup

Follow the [Getting Started](./GETTING_STARTED.md) guide first.

### 2. Project Structure

Understand the [Project Structure](./PROJECT_STRUCTURE.md) before making changes.

### 3. Building & Running

```bash
# Build the project
dotnet build

# Run in development mode
dotnet run

# Run with hot reload
dotnet watch run

# Run tests
dotnet test
```

## Code Standards

### C# Conventions

Follow standard C# naming and style conventions:

```csharp
// Classes: PascalCase
public class BlogService { }

// Methods: PascalCase
public async Task<BlogPostDto> GetPostAsync(int id) { }

// Properties: PascalCase
public string Title { get; set; }

// Private fields: _camelCase
private readonly IRepository<BlogPost> _repository;

// Local variables: camelCase
var blogPosts = await _repository.GetAllAsync();

// Constants: UPPER_CASE
private const int MAX_PAGE_SIZE = 100;
```

### Async/Await

Always use async/await for I/O operations:

```csharp
// ✓ Correct
public async Task<IActionResult> GetPost(int id)
{
    var post = await _service.GetPostByIdAsync(id);
    return Ok(post);
}

// ❌ Wrong - blocks thread
public IActionResult GetPost(int id)
{
    var post = _service.GetPostByIdAsync(id).Result;  // Deadlock risk!
    return Ok(post);
}
```

### Error Handling

Use try-catch in services, not controllers:

```csharp
// Service
public async Task<BlogPostDto?> GetPostByIdAsync(int id)
{
    try
    {
        return await _repository.GetByIdAsync(id);
    }
    catch (DbException ex)
    {
        _logger.LogError(ex, "Database error retrieving post {PostId}", id);
        throw new ServiceException("Failed to retrieve post", ex);
    }
}

// Controller
[HttpGet("{id}")]
public async Task<IActionResult> GetPost(int id)
{
    try
    {
        var post = await _service.GetPostByIdAsync(id);
        return post == null ? NotFound() : Ok(post);
    }
    catch (ServiceException ex)
    {
        return StatusCode(500, new { error = ex.Message });
    }
}
```

### Dependency Injection

Always inject dependencies, never instantiate:

```csharp
// ✓ Correct
public class BlogController : Controller
{
    private readonly IBlogService _service;
    
    public BlogController(IBlogService service)
    {
        _service = service;
    }
}

// ❌ Wrong - tight coupling
public class BlogController : Controller
{
    public IActionResult GetPost(int id)
    {
        var service = new BlogService();  // Anti-pattern!
        return Ok(service.GetPost(id));
    }
}
```

### Database Access

Use repositories and services, not direct DbContext:

```csharp
// ✓ Correct - via repository
public async Task<BlogPost?> GetPostByIdAsync(int id)
{
    return await _repository.GetByIdAsync(id);
}

// ✓ Also correct - via Dapper
public async Task<IEnumerable<BlogPost>> GetPublishedPostsAsync()
{
    var connection = await _factory.CreateConnectionAsync();
    return await connection.QueryAsync<BlogPost>(
        "SELECT * FROM blog_posts WHERE status = @status",
        new { status = "published" }
    );
}

// ❌ Wrong - direct DbContext access
public IActionResult GetPosts()
{
    var posts = _dbContext.BlogPosts.ToList();  // No async, poor separation
    return Ok(posts);
}
```

## Adding Features

### 1. Create a Model

```csharp
// Models/Feature.cs
public class Feature
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public int? UserId { get; set; }
    public ApplicationUser? User { get; set; }
}
```

### 2. Create Repository Interface

```csharp
// Data/Repositories/IFeatureRepository.cs
public interface IFeatureRepository
{
    Task<IEnumerable<Feature>> GetAllAsync();
    Task<Feature?> GetByIdAsync(int id);
    Task<int> AddAsync(Feature feature);
    Task UpdateAsync(Feature feature);
    Task DeleteAsync(int id);
}
```

### 3. Create Service Interface

```csharp
// Services/Interfaces/IFeatureService.cs
public interface IFeatureService
{
    Task<IEnumerable<FeatureDto>> GetAllAsync();
    Task<FeatureDto?> GetByIdAsync(int id);
    Task<int> CreateAsync(CreateFeatureDto dto);
    Task UpdateAsync(int id, UpdateFeatureDto dto);
    Task DeleteAsync(int id);
}
```

### 4. Implement Service

```csharp
// Services/Implementations/FeatureService.cs
public class FeatureService : IFeatureService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public FeatureService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<FeatureDto>> GetAllAsync()
    {
        var features = await _unitOfWork.Features.GetAllAsync();
        return _mapper.Map<IEnumerable<FeatureDto>>(features);
    }

    public async Task<int> CreateAsync(CreateFeatureDto dto)
    {
        var feature = _mapper.Map<Feature>(dto);
        feature.CreatedAt = DateTime.UtcNow;
        
        var id = await _unitOfWork.Features.AddAsync(feature);
        await _unitOfWork.SaveChangesAsync();
        return id;
    }
}
```

### 5. Create Controller

```csharp
// Controllers/FeaturesController.cs
[Route("[controller]")]
public class FeaturesController : Controller
{
    private readonly IFeatureService _service;

    public FeaturesController(IFeatureService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var features = await _service.GetAllAsync();
        return View(features);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Detail(int id)
    {
        var feature = await _service.GetByIdAsync(id);
        if (feature == null)
            return NotFound();
        return View(feature);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create(CreateFeatureDto dto)
    {
        if (!ModelState.IsValid)
            return View(dto);

        var id = await _service.CreateAsync(dto);
        return RedirectToAction(nameof(Detail), new { id });
    }
}
```

### 6. Register in DI Container

```csharp
// Services/Extensions/ServiceExtensions.cs
public static IServiceCollection AddCustomServices(this IServiceCollection services)
{
    services.AddScoped<IFeatureService, FeatureService>();
    services.AddScoped<IFeatureRepository, FeatureRepository>();
    // ... other services
    return services;
}
```

### 7. Create Views

```html
<!-- Views/Features/Index.cshtml -->
@model IEnumerable<FeatureDto>

<div class="features-list">
    @foreach (var feature in Model)
    {
        <div class="feature-card">
            <h3>@feature.Name</h3>
            <p>@feature.Description</p>
            <a asp-action="Detail" asp-route-id="@feature.Id">View</a>
        </div>
    }
</div>
```

## Database Migrations

### Add Migration

```bash
cd MostafaSaidPortfolio
dotnet ef migrations add AddFeatureTable
```

### View Pending Migrations

```bash
dotnet ef migrations list
```

### Apply Migrations

```bash
dotnet ef database update
```

### Rollback Migration

```bash
dotnet ef migrations remove
```

## Testing

### Unit Testing Setup

```bash
dotnet new xunit -n MostafaSaidPortfolio.Tests
dotnet add MostafaSaidPortfolio.Tests reference MostafaSaidPortfolio
```

### Example Unit Test

```csharp
using Xunit;
using Moq;

public class BlogServiceTests
{
    [Fact]
    public async Task GetPostByIdAsync_WithValidId_ReturnsPost()
    {
        // Arrange
        var repositoryMock = new Mock<IRepository<BlogPost>>();
        var post = new BlogPost { Id = 1, Title = "Test Post" };
        repositoryMock.Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(post);

        var service = new BlogService(repositoryMock.Object);

        // Act
        var result = await service.GetPostByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Test Post", result.Title);
    }

    [Fact]
    public async Task GetPostByIdAsync_WithInvalidId_ReturnsNull()
    {
        // Arrange
        var repositoryMock = new Mock<IRepository<BlogPost>>();
        repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
            .ReturnsAsync((BlogPost?)null);

        var service = new BlogService(repositoryMock.Object);

        // Act
        var result = await service.GetPostByIdAsync(999);

        // Assert
        Assert.Null(result);
    }
}
```

### Run Tests

```bash
dotnet test
```

## Debugging

### Enable Debug Logging

In `appsettings.Development.json`:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Debug",
      "Microsoft.EntityFrameworkCore.Database.Command": "Debug"
    }
  }
}
```

### View SQL Queries

```csharp
.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
```

### Visual Studio Debugging

1. Set breakpoints (F9)
2. Press F5 to start debugging
3. Use Debug menu to step through code
4. Inspect variables in Watch window

## Performance Optimization

### 1. Database Queries

```csharp
// ✓ Efficient - only select needed columns
var posts = await connection.QueryAsync<BlogPostDto>(
    "SELECT id, title, slug, created_at FROM blog_posts LIMIT 10"
);

// ❌ Inefficient - selects all columns
var posts = await connection.QueryAsync<BlogPost>(
    "SELECT * FROM blog_posts"
);
```

### 2. N+1 Query Problem

```csharp
// ❌ N+1 problem
var posts = await _repository.GetAllAsync();
foreach (var post in posts)
{
    var comments = await _repository.GetCommentsAsync(post.Id);  // Query per post!
}

// ✓ Correct - load related data
var posts = await _repository.GetAllWithCommentsAsync();
```

### 3. Caching

```csharp
public class BlogService
{
    private readonly IMemoryCache _cache;
    private const string CATEGORIES_CACHE_KEY = "blog_categories";

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        if (!_cache.TryGetValue(CATEGORIES_CACHE_KEY, out var categories))
        {
            categories = await _repository.GetCategoriesAsync();
            _cache.Set(CATEGORIES_CACHE_KEY, categories, TimeSpan.FromHours(1));
        }
        return categories;
    }
}
```

### 4. Async All the Way

```csharp
// ✓ Correct
public async Task<IActionResult> Index()
{
    var posts = await _service.GetPostsAsync();
    return View(posts);
}

// ❌ Blocks threads
public async Task<IActionResult> Index()
{
    var posts = await _service.GetPostsAsync();
    Thread.Sleep(1000);  // Blocks!
    return View(posts);
}
```

## Git Workflow

### Create Feature Branch

```bash
git checkout -b feature/new-feature
```

### Commit Changes

```bash
git add .
git commit -m "Add new feature"
```

### Push to Remote

```bash
git push origin feature/new-feature
```

### Create Pull Request

Open GitHub and create a PR from your branch.

### Branch Naming

- `feature/feature-name` - New features
- `bugfix/bug-name` - Bug fixes
- `docs/update-docs` - Documentation
- `refactor/refactor-name` - Code refactoring

## Troubleshooting

### EF Core Migration Issues

**Issue**: Migration fails with "Cannot open database"

**Solution**:
```bash
dotnet ef database drop
dotnet ef database update
```

### Port Already in Use

**Solution**: Change port in `launchSettings.json` or:
```bash
dotnet run --urls "http://localhost:5001"
```

### NuGet Package Restore Issues

**Solution**:
```bash
dotnet clean
dotnet restore
dotnet build
```

### Circular Dependency in DI

**Issue**: "A circular dependency was detected"

**Solution**: Use factory pattern or lazy initialization:
```csharp
builder.Services.AddScoped<IServiceA>(sp => 
    new ServiceA(sp.GetRequiredService<IServiceB>())
);
```

## Best Practices

1. **Keep Controllers Thin** - Move logic to services
2. **Use DTOs** - Don't return domain entities to clients
3. **Validate Input** - Use `[Required]`, `[StringLength]`, etc.
4. **Log Errors** - Use ILogger for debugging
5. **Handle Exceptions** - Gracefully fail with meaningful messages
6. **Async All I/O** - Database, HTTP, file operations
7. **Secure Data** - Never log sensitive information
8. **Document Code** - Add XML comments to public members

## Resources

- [ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core/)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [Dapper Documentation](https://github.com/DapperLib/Dapper)
- [C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)

## Support

For questions or issues:
1. Check existing documentation
2. Search GitHub issues
3. Review code comments
4. Ask the team
