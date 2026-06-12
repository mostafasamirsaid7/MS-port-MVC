# API Reference

## Base URL

```
http://localhost:5000/api
```

## Authentication

The API supports Bearer token authentication (JWT ready):

```bash
Authorization: Bearer YOUR_JWT_TOKEN
```

Currently, most endpoints are public. Admin endpoints require authentication and Admin role.

## Response Format

All responses follow this format:

### Success Response

```json
{
  "success": true,
  "data": { /* response data */ },
  "message": "Operation successful"
}
```

### Error Response

```json
{
  "success": false,
  "error": "Error message",
  "details": "Detailed error information"
}
```

---

## Endpoints

### Blog Posts

#### List All Posts

```
GET /api/blog
```

**Query Parameters:**
- `page` (int, default: 1) - Page number
- `pageSize` (int, default: 10) - Items per page
- `categoryId` (int, optional) - Filter by category
- `search` (string, optional) - Search posts

**Response:**

```json
{
  "success": true,
  "data": {
    "items": [
      {
        "id": 1,
        "title": "First Post",
        "slug": "first-post",
        "excerpt": "Post summary...",
        "content": "Full post content...",
        "authorId": "user-123",
        "categoryId": 1,
        "status": "published",
        "createdAt": "2024-01-15T10:30:00Z",
        "updatedAt": "2024-01-15T10:30:00Z",
        "tags": ["tag1", "tag2"],
        "commentCount": 5
      }
    ],
    "totalCount": 42,
    "pageNumber": 1,
    "pageSize": 10
  }
}
```

---

#### Get Single Post

```
GET /api/blog/{id}
```

**Path Parameters:**
- `id` (int) - Post ID

**Response:**

```json
{
  "success": true,
  "data": {
    "id": 1,
    "title": "First Post",
    "slug": "first-post",
    "content": "Full post content...",
    "author": {
      "id": "user-123",
      "name": "Mostafa Said",
      "email": "mostafa@example.com"
    },
    "category": {
      "id": 1,
      "name": "Technology",
      "slug": "technology"
    },
    "tags": [
      { "id": 1, "name": "C#", "slug": "csharp" },
      { "id": 2, "name": "ASP.NET", "slug": "aspnet" }
    ],
    "comments": [
      {
        "id": 1,
        "author": "John Doe",
        "content": "Great post!",
        "createdAt": "2024-01-15T11:00:00Z"
      }
    ],
    "status": "published",
    "createdAt": "2024-01-15T10:30:00Z",
    "updatedAt": "2024-01-15T10:30:00Z",
    "viewCount": 150
  }
}
```

---

#### Create Post

```
POST /api/blog
```

**Authentication**: Required (any authenticated user)

**Request Body:**

```json
{
  "title": "New Post",
  "slug": "new-post",
  "content": "Post content here...",
  "categoryId": 1,
  "tags": ["tag1", "tag2"],
  "status": "draft"
}
```

**Response:** (201 Created)

```json
{
  "success": true,
  "data": {
    "id": 2,
    "title": "New Post",
    "slug": "new-post",
    "createdAt": "2024-01-16T10:00:00Z"
  }
}
```

---

#### Update Post

```
PUT /api/blog/{id}
```

**Path Parameters:**
- `id` (int) - Post ID

**Authentication**: Required (post author or admin)

**Request Body:** (same as create)

**Response:** (200 OK)

---

#### Delete Post

```
DELETE /api/blog/{id}
```

**Authentication**: Required (post author or admin)

**Response:** (204 No Content)

---

### Projects

#### List All Projects

```
GET /api/projects
```

**Query Parameters:**
- `page` (int, default: 1)
- `pageSize` (int, default: 10)
- `technology` (string, optional) - Filter by technology

**Response:**

```json
{
  "success": true,
  "data": {
    "items": [
      {
        "id": 1,
        "title": "Portfolio Website",
        "slug": "portfolio-website",
        "description": "Personal portfolio showcasing projects...",
        "technologies": ["C#", "ASP.NET Core", "PostgreSQL"],
        "liveUrl": "https://example.com",
        "sourceUrl": "https://github.com/example/repo",
        "imageUrl": "/images/project-1.jpg",
        "featured": true,
        "createdAt": "2024-01-10T00:00:00Z"
      }
    ],
    "totalCount": 15,
    "pageNumber": 1,
    "pageSize": 10
  }
}
```

---

#### Get Single Project

```
GET /api/projects/{id}
```

**Response:** Single project object (same as list item)

---

#### Create Project

```
POST /api/projects
```

**Authentication**: Required (admin only)

**Request Body:**

```json
{
  "title": "New Project",
  "slug": "new-project",
  "description": "Project description...",
  "technologies": ["Tech1", "Tech2"],
  "liveUrl": "https://example.com",
  "sourceUrl": "https://github.com/user/repo",
  "imageUrl": "/images/project.jpg",
  "featured": false
}
```

**Response:** (201 Created)

---

### Testimonials

#### List All Testimonials

```
GET /api/testimonials
```

**Query Parameters:**
- `page` (int, default: 1)
- `pageSize` (int, default: 10)
- `featured` (bool, optional) - Show only featured

**Response:**

```json
{
  "success": true,
  "data": {
    "items": [
      {
        "id": 1,
        "authorName": "John Doe",
        "position": "CTO at TechCorp",
        "content": "Mostafa is an excellent developer...",
        "rating": 5,
        "imageUrl": "/images/testimonial-1.jpg",
        "featured": true,
        "createdAt": "2024-01-12T00:00:00Z"
      }
    ],
    "totalCount": 8,
    "pageNumber": 1,
    "pageSize": 10
  }
}
```

---

#### Get Single Testimonial

```
GET /api/testimonials/{id}
```

**Response:** Single testimonial object

---

#### Create Testimonial

```
POST /api/testimonials
```

**Authentication**: Required (admin only)

**Request Body:**

```json
{
  "authorName": "Jane Smith",
  "position": "Manager at StartUp",
  "content": "Testimonial content...",
  "rating": 5,
  "imageUrl": "/images/testimonial.jpg",
  "featured": false
}
```

**Response:** (201 Created)

---

### Events

#### List All Events

```
GET /api/events
```

**Query Parameters:**
- `page` (int, default: 1)
- `pageSize` (int, default: 10)
- `status` (string, optional) - "upcoming", "ongoing", "completed"
- `from` (date, optional) - Start date (YYYY-MM-DD)
- `to` (date, optional) - End date (YYYY-MM-DD)

**Response:**

```json
{
  "success": true,
  "data": {
    "items": [
      {
        "id": 1,
        "title": "Web Development Workshop",
        "description": "Learn ASP.NET Core...",
        "date": "2024-02-15T10:00:00Z",
        "location": "Online",
        "status": "upcoming",
        "registeredCount": 45,
        "createdAt": "2024-01-10T00:00:00Z"
      }
    ],
    "totalCount": 12,
    "pageNumber": 1,
    "pageSize": 10
  }
}
```

---

### Search

#### Global Search

```
GET /api/search
```

**Query Parameters:**
- `query` (string, required) - Search term
- `type` (string, optional) - "blog", "projects", "events", or omit for all

**Response:**

```json
{
  "success": true,
  "data": {
    "blog": [
      {
        "id": 1,
        "title": "Result matching query",
        "excerpt": "Search term highlighted...",
        "url": "/blog/result"
      }
    ],
    "projects": [
      {
        "id": 1,
        "title": "Project matching query",
        "excerpt": "Project description snippet...",
        "url": "/projects/project"
      }
    ],
    "events": []
  }
}
```

---

### Newsletter

#### Subscribe

```
POST /api/newsletter/subscribe
```

**Request Body:**

```json
{
  "email": "subscriber@example.com"
}
```

**Response:**

```json
{
  "success": true,
  "message": "Successfully subscribed to newsletter"
}
```

---

#### Unsubscribe

```
POST /api/newsletter/unsubscribe
```

**Query Parameters:**
- `token` (string) - Unsubscribe token from email

**Response:**

```json
{
  "success": true,
  "message": "Successfully unsubscribed"
}
```

---

### Contact

#### Submit Contact Form

```
POST /api/contact/submit
```

**Request Body:**

```json
{
  "name": "John Doe",
  "email": "john@example.com",
  "subject": "Inquiry",
  "message": "Your message here..."
}
```

**Response:** (201 Created)

```json
{
  "success": true,
  "data": {
    "id": 1,
    "reference": "MSG-20240115-0001",
    "status": "received"
  }
}
```

---

## Error Codes

| Code | Meaning |
|------|---------|
| 200 | OK - Request successful |
| 201 | Created - Resource created |
| 204 | No Content - Successful deletion |
| 400 | Bad Request - Invalid parameters |
| 401 | Unauthorized - Authentication required |
| 403 | Forbidden - Insufficient permissions |
| 404 | Not Found - Resource doesn't exist |
| 422 | Unprocessable Entity - Validation error |
| 500 | Internal Server Error |

---

## Rate Limiting

Currently, there is no rate limiting. Future versions may implement:
- 100 requests per minute per IP
- Burst allowance for authenticated users

---

## Pagination

List endpoints support pagination:

```
GET /api/blog?page=2&pageSize=20
```

Response includes:

```json
{
  "totalCount": 150,
  "pageNumber": 2,
  "pageSize": 20,
  "totalPages": 8
}
```

---

## Sorting

Some endpoints support sorting:

```
GET /api/blog?sortBy=createdAt&sortOrder=desc
```

Valid sort fields vary by endpoint (see specific endpoint docs).

---

## Filtering

Use query parameters to filter results:

```
GET /api/blog?categoryId=1&status=published
GET /api/projects?featured=true
GET /api/events?status=upcoming
```

---

## CORS

CORS is configured to allow requests from:

```
GET /api/blog HTTP/1.1
Access-Control-Allow-Origin: *
```

Configure in `Program.cs`:

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin().AllowAnyMethod());
});
```

---

## Versioning

Current API version: **v1**

Future versions will use:

```
GET /api/v2/blog
```

---

## Examples

### Using cURL

```bash
# Get all posts
curl -X GET "http://localhost:5000/api/blog"

# Get single post
curl -X GET "http://localhost:5000/api/blog/1"

# Create post (with auth)
curl -X POST "http://localhost:5000/api/blog" \
  -H "Authorization: Bearer TOKEN" \
  -H "Content-Type: application/json" \
  -d '{"title":"New Post","slug":"new-post","content":"Content..."}'

# Search
curl -X GET "http://localhost:5000/api/search?query=aspnet&type=blog"
```

### Using JavaScript/Fetch

```javascript
// Get all posts
fetch('http://localhost:5000/api/blog')
  .then(res => res.json())
  .then(data => console.log(data));

// Create post
fetch('http://localhost:5000/api/blog', {
  method: 'POST',
  headers: {
    'Authorization': `Bearer ${token}`,
    'Content-Type': 'application/json'
  },
  body: JSON.stringify({
    title: 'New Post',
    slug: 'new-post',
    content: 'Content here...'
  })
})
.then(res => res.json())
.then(data => console.log(data));
```

---

## Deprecation Policy

Deprecated endpoints will be marked with a `Deprecation` header:

```
Deprecation: true
Sunset: Wed, 21 Dec 2024 00:00:00 GMT
```

The API will maintain backward compatibility for at least 6 months before removal.
