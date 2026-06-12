using Microsoft.EntityFrameworkCore;
using MostafaSaidPortfolio.Data;
using MostafaSaidPortfolio.Extensions;
using MostafaSaidPortfolio.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext with SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Add HttpContextAccessor
builder.Services.AddHttpContextAccessor();

// Add custom services/extensions
builder.Services.AddCustomServices();
builder.Services.AddCustomEmail();
builder.Services.AddCustomLocalization();
builder.Services.AddCustomNewsletter();
builder.Services.AddCustomEvents();

// Add MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Create/migrate the database on startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.EnsureCreated();
}

// Configure Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
