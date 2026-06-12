# Features

## Core Features Overview

### 1. Blog System

**Blog Management**
- Create, edit, delete blog posts
- Organize posts with categories and tags
- Full-text search on blog content
- Comments on posts
- Draft and published status

**Controllers**: `BlogController`

**Models**: `BlogPost`, `Comment`, `Category`, `Tag`

**Services**: `IBlogService`

**Views**: `Views/Blog/`

Example usage:

```csharp
[Authorize]
public async Task<IActionResult> CreatePost(CreateBlogPostDto dto)
{
    var postId = await _blogService.CreatePostAsync(dto);
    return RedirectToAction(nameof(GetPost), new { id = postId });
}
```

---

### 2. Project Showcase

**Project Features**
- Display portfolio projects with descriptions
- Technology stack per project
- Links to live demos and source code
- Project filtering and search
- Image galleries

**Controllers**: `ProjectsController`

**Models**: `Project`

**Services**: `IProjectService`

**Views**: `Views/Projects/`

---

### 3. Testimonials

**Testimonial System**
- Display user testimonials
- Star ratings (1-5)
- Author name and position
- Featured testimonials on homepage

**Controllers**: `TestimonialsController`

**Models**: `Testimonial`

**Services**: `ITestimonialService`

**Views**: `Views/Testimonials/`

---

### 4. Events Management

**Event Features**
- Upcoming events listing
- Event date, time, and location
- Event descriptions
- Status tracking (upcoming, ongoing, completed)
- Event filtering

**Controllers**: `EventsController`

**Models**: `Event`

**Services**: `IEventsService`

**Views**: `Views/Events/`

---

### 5. Contact Forms

**Contact Features**
- Visitors can submit contact messages
- Sender name, email, subject, message
- Message storage in database
- Admin notification via email
- Response tracking

**Controllers**: `ContactController`

**Models**: `ContactMessage`

**ViewModel**: `ContactViewModel`

**Views**: `Views/Contact/`

Example form:

```html
<form asp-controller="Contact" asp-action="Submit" method="post">
    <input asp-for="Name" required />
    <input asp-for="Email" type="email" required />
    <textarea asp-for="Message" required></textarea>
    <button type="submit">Send</button>
</form>
```

---

### 6. Newsletter Subscription

**Newsletter Features**
- Email subscription management
- Unsubscribe functionality
- Subscriber list for bulk emails
- Subscription confirmation

**Controllers**: `NewsletterController`

**Models**: `NewsletterSubscriber`

**Services**: `INewsletterService`

**Views**: `Views/Newsletter/`

---

### 7. User Authentication

**Authentication System**
- User registration
- Email-based login
- Password reset via token
- Role-based access control (Admin, User)
- Session management

**Controllers**: `AccountController`

**Models**: `ApplicationUser`

**Built with**: ASP.NET Identity

**Features**:
- Secure password hashing (bcrypt)
- Lockout after failed attempts
- Password complexity requirements configurable
- Two-factor authentication ready

Configuration in `Program.cs`:

```csharp
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<ApplicationDbContext>();
```

---

### 8. Admin Dashboard

**Admin Area**
- Dashboard overview
- Content management
- User management
- Settings configuration
- Analytics

**Location**: `Areas/Admin/`

**Access**: Requires Admin role

**Routes**: `http://localhost/admin/dashboard`

---

### 9. Search Functionality

**Search Features**
- Full-text search across blog posts
- Search by title, content, tags, categories
- Search results pagination
- Search term highlighting

**Controllers**: `SearchController`

**Views**: `Views/Search/`

---

### 10. Localization (Bilingual)

**Language Support**
- English (default)
- Arabic

**Implementation**:
- Resource files (.resx files)
- Cookie-based culture selection
- URL-based culture prefixes
- Browser language detection fallback

**Switching Languages**:

```csharp
[HttpPost]
public IActionResult SetCulture(string culture, string returnUrl)
{
    Response.Cookies.Append(
        CookieRequestCultureProvider.DefaultCookieName,
        CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
        new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
    );
    return Redirect(returnUrl ?? "/");
}
```

**In Views**:

```html
<!-- Automatic localization -->
@Html.DisplayNameFor(m => m.Title)

<!-- Manual localization -->
<p>@Localizer["WelcomeMessage"]</p>
```

---

### 11. Email Service

**Email Capabilities**
- Contact form notifications
- Newsletter distribution
- Password reset emails
- Welcome emails

**Configuration** in `appsettings.json`:

```json
{
  "EmailSettings": {
    "SmtpServer": "smtp.gmail.com",
    "Port": 587,
    "SenderEmail": "sender@example.com",
    "SenderName": "Portfolio",
    "Username": "your-email@gmail.com",
    "Password": "app-specific-password"
  }
}
```

**Service Interface**: `IEmailService`

**Methods**:
- `SendAsync(to, subject, body)`
- `SendBulkAsync(recipients, subject, body)`

---

### 12. API Endpoints

**REST API** for external integrations:

**Location**: `Controllers/Api/`

**Features**:
- Blog posts API
- Projects API
- Testimonials API
- Events API
- Search API

**Authentication**: Bearer token (JWT ready)

Example endpoint:

```csharp
[ApiController]
[Route("api/[controller]")]
public class BlogController : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<BlogPostDto>> GetPost(int id)
    {
        var post = await _blogService.GetPostByIdAsync(id);
        if (post == null)
            return NotFound();
        return Ok(post);
    }
}
```

---

## Feature Dependencies

| Feature | Requires |
|---------|----------|
| Blog | Category, Tag models |
| Comments | BlogPost, ApplicationUser |
| Events | Database storage |
| Contact | Email service |
| Newsletter | Email service |
| Admin | Authorization (Admin role) |
| Search | Blog posts, full-text indexing |
| Localization | Resource files (.resx) |

---

## Upcoming Features

Potential enhancements planned for future versions:

- [ ] Real-time notifications
- [ ] Social media integration
- [ ] Advanced analytics dashboard
- [ ] Content scheduling
- [ ] SEO optimization tools
- [ ] Performance caching layer
- [ ] Mobile app integration

---

## Feature Flags

Feature flags can be enabled/disabled via configuration:

```json
{
  "Features": {
    "BlogEnabled": true,
    "AdminDashboardEnabled": true,
    "NewsletterEnabled": true
  }
}
```

Usage in code:

```csharp
if (_configuration.GetValue<bool>("Features:BlogEnabled"))
{
    // Blog feature code
}
```

---

## Performance Features

- **Lazy Loading**: Blog comments loaded on demand
- **Pagination**: Large datasets paginated (10, 25, 50 items per page)
- **Caching**: Static blog categories cached in memory
- **Async/Await**: All I/O operations non-blocking
- **Connection Pooling**: Database connections reused

---

## Security Features

- **HTTPS**: Enforced in production
- **CSRF Protection**: Anti-forgery tokens on all forms
- **XSS Prevention**: Razor templating auto-encodes output
- **SQL Injection Prevention**: Parameterized queries (EF Core + Dapper)
- **Password Security**: Bcrypt hashing via ASP.NET Identity
- **Authorization Checks**: Role-based and claim-based
