using System;
using MostafaSaidPortfolio.Models;
using Microsoft.EntityFrameworkCore;

namespace MostafaSaidPortfolio.Data
{
    public static class DataSeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            // Seed Users (authors)
            builder.Entity<User>().HasData(
                new User { Id = 1, Name = "Mostafa Said" }
            );

            // Seed Categories
            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Development" },
                new Category { Id = 2, Name = "Design" },
                new Category { Id = 3, Name = "Productivity" },
                new Category { Id = 4, Name = "API Integration" }
            );

            // Seed Projects (CategoryId must reference a valid category)
            builder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    Title = "Portfolio Website",
                    Description = "A personal portfolio showcasing projects, blog posts, and contact info.",
                    LongDescription = "",
                    TechnologyStack = "ASP.NET Core, EF Core, Bootstrap",
                    LiveUrl = "https://example.com/portfolio",
                    GitHubUrl = "https://github.com/mostafasaid/portfolio",
                    ImageUrl = "/images/projects/portfolio.png",
                    ThumbnailUrl = "",
                    CategoryId = 1,
                    CreatedAt = new DateTime(2023, 01, 01),
                    UpdatedAt = new DateTime(2023, 01, 01)
                },
                new Project
                {
                    Id = 2,
                    Title = "E-commerce App",
                    Description = "An online shop built with ASP.NET Core and EF Core.",
                    LongDescription = "",
                    TechnologyStack = "ASP.NET Core, EF Core, SQL Server",
                    LiveUrl = "https://example.com/shop",
                    GitHubUrl = "https://github.com/mostafasaid/ecommerce",
                    ImageUrl = "/images/projects/ecommerce.png",
                    ThumbnailUrl = "",
                    CategoryId = 1,
                    CreatedAt = new DateTime(2023, 02, 15),
                    UpdatedAt = new DateTime(2023, 02, 15)
                },
                new Project
                {
                    Id = 3,
                    Title = "Blog Platform",
                    Description = "A full-featured blog platform with authentication and CRUD operations.",
                    LongDescription = "",
                    TechnologyStack = "ASP.NET Core, Identity, EF Core",
                    LiveUrl = "https://example.com/blog",
                    GitHubUrl = "https://github.com/mostafasaid/blog-platform",
                    ImageUrl = "/images/projects/blog.png",
                    ThumbnailUrl = "",
                    CategoryId = 1,
                    CreatedAt = new DateTime(2023, 04, 05),
                    UpdatedAt = new DateTime(2023, 04, 05)
                },
                new Project
                {
                    Id = 4,
                    Title = "Task Manager App",
                    Description = "A productivity app for managing tasks with deadlines and priorities.",
                    LongDescription = "",
                    TechnologyStack = "ASP.NET Core, JavaScript, Bootstrap",
                    LiveUrl = "https://example.com/tasks",
                    GitHubUrl = "https://github.com/mostafasaid/task-manager",
                    ImageUrl = "/images/projects/tasks.png",
                    ThumbnailUrl = "",
                    CategoryId = 3,
                    CreatedAt = new DateTime(2023, 05, 20),
                    UpdatedAt = new DateTime(2023, 05, 20)
                },
                new Project
                {
                    Id = 5,
                    Title = "Weather Dashboard",
                    Description = "A real-time weather dashboard using public APIs and responsive UI.",
                    LongDescription = "",
                    TechnologyStack = "ASP.NET Core, REST APIs, Bootstrap",
                    LiveUrl = "https://example.com/weather",
                    GitHubUrl = "https://github.com/mostafasaid/weather-dashboard",
                    ImageUrl = "/images/projects/weather.png",
                    ThumbnailUrl = "",
                    CategoryId = 4,
                    CreatedAt = new DateTime(2023, 06, 10),
                    UpdatedAt = new DateTime(2023, 06, 10)
                }
            );

            // Seed BlogPosts
            builder.Entity<BlogPost>().HasData(
                new BlogPost
                {
                    Id = 1,
                    Title = "Getting Started with ASP.NET Core",
                    Content = "ASP.NET Core is a cross-platform framework for building web apps...",
                    Summary = "An introduction to ASP.NET Core web development.",
                    Slug = "getting-started-with-aspnet-core",
                    MetaTitle = "Getting Started with ASP.NET Core",
                    MetaDescription = "Learn the basics of ASP.NET Core, a cross-platform framework for building web apps.",
                    CreatedAt = new DateTime(2023, 03, 01),
                    UpdatedAt = new DateTime(2023, 03, 01),
                    FeaturedImageUrl = "/images/blog1.jpg",
                    IsPublished = true,
                    CategoryId = 1,
                    AuthorId = 1
                },
                new BlogPost
                {
                    Id = 2,
                    Title = "UI/UX Design Principles",
                    Content = "Design is not just what it looks like and feels like. Design is how it works...",
                    Summary = "Core principles for creating effective user interfaces.",
                    Slug = "ui-ux-design-principles",
                    MetaTitle = "UI/UX Design Principles",
                    MetaDescription = "Explore the fundamental principles of UI/UX design for better user experiences.",
                    CreatedAt = new DateTime(2023, 03, 10),
                    UpdatedAt = new DateTime(2023, 03, 10),
                    FeaturedImageUrl = "/images/blog1.jpg",
                    IsPublished = true,
                    CategoryId = 2,
                    AuthorId = 1
                },
                new BlogPost
                {
                    Id = 3,
                    Title = "Building a Task Manager App",
                    Content = "In this post, I walk through building a productivity app with ASP.NET Core...",
                    Summary = "Step-by-step guide to building a task manager application.",
                    Slug = "building-a-task-manager-app",
                    MetaTitle = "Building a Task Manager App",
                    MetaDescription = "Learn how to build a productivity task manager app with ASP.NET Core.",
                    CreatedAt = new DateTime(2023, 04, 12),
                    UpdatedAt = new DateTime(2023, 04, 12),
                    FeaturedImageUrl = "/images/blog1.jpg",
                    IsPublished = true,
                    CategoryId = 3,
                    AuthorId = 1
                },
                new BlogPost
                {
                    Id = 4,
                    Title = "Integrating Weather APIs in .NET",
                    Content = "Learn how to fetch real-time weather data from external APIs and display it in your app...",
                    Summary = "How to integrate external weather APIs into your .NET application.",
                    Slug = "integrating-weather-apis-in-dotnet",
                    MetaTitle = "Integrating Weather APIs in .NET",
                    MetaDescription = "Fetch real-time weather data from external APIs and display it in your .NET app.",
                    CreatedAt = new DateTime(2023, 05, 05),
                    UpdatedAt = new DateTime(2023, 05, 05),
                    FeaturedImageUrl = "/images/blog1.jpg",
                    IsPublished = true,
                    CategoryId = 4,
                    AuthorId = 1
                },
                new BlogPost
                {
                    Id = 5,
                    Title = "Creating a Blog Platform with ASP.NET Core",
                    Content = "Step-by-step guide to building a full-featured blog platform with authentication and CRUD...",
                    Summary = "Build a full-featured blog platform using ASP.NET Core.",
                    Slug = "creating-a-blog-platform-with-aspnet-core",
                    MetaTitle = "Creating a Blog Platform with ASP.NET Core",
                    MetaDescription = "A comprehensive guide to building a blog platform with authentication and CRUD in ASP.NET Core.",
                    CreatedAt = new DateTime(2023, 06, 01),
                    UpdatedAt = new DateTime(2023, 06, 01),
                    FeaturedImageUrl = "/images/blog1.jpg",
                    IsPublished = true,
                    CategoryId = 1,
                    AuthorId = 1
                }
            );
        }
    }
}
