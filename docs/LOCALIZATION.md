# Localization Guide

## Overview

The application supports **English** and **Arabic** with resource-based localization using `.resx` files.

## Current Structure Issues & Solutions

### ❌ Issues Identified

1. **Single Monolithic File** - All strings in one `SharedResource.resx`
2. **Missing Form Validation** - No localized validation messages
3. **Missing Error Pages** - No localized 404/500 error messages
4. **Missing Dialog/Modal Strings** - No localized confirmation messages
5. **Missing Auth Strings** - No localized login/register/password labels
6. **Missing Navigation Alt Text** - Accessibility strings missing
7. **Duplicate Resources** - Same strings in both EN and AR files
8. **No Feature-Based Organization** - Resources not grouped by module

### ✅ Recommended Solution

**Split into focused resource files by feature:**

```
Resources/
├── SharedResource.resx           # Navigation, footer, common
├── SharedResource.ar.resx
├── FormResource.resx             # Form labels, validation
├── FormResource.ar.resx
├── AuthResource.resx             # Login, register, password
├── AuthResource.ar.resx
├── ValidationResource.resx       # Validation messages, errors
├── ValidationResource.ar.resx
└── ErrorResource.resx            # 404, 500, exceptions
└── ErrorResource.ar.resx
```

---

## File Structure by Purpose

### 1. SharedResource (Existing - Well Organized)

**Use for**: Navigation, footer, hero, stats, common UI

**Files**: `SharedResource.resx`, `SharedResource.ar.resx`

**Examples**:
- Navigation labels: `Nav_Home`, `Nav_Blog`
- Footer: `Footer_QuickLinks`, `Footer_Rights`
- Common buttons: `Common_Featured`, `Common_GitHub`

**When to use**:
```csharp
@inject IStringLocalizer<SharedResource> L

<p>@L["Nav_Home"]</p>
```

---

### 2. FormResource (New - For Form Inputs)

**Use for**: Form labels, placeholders, form-specific buttons

**Required entries**:

```xml
<!-- Auth Forms -->
<data name="Auth_Username" xml:space="preserve"><value>Username</value></data>
<data name="Auth_Email" xml:space="preserve"><value>Email Address</value></data>
<data name="Auth_Password" xml:space="preserve"><value>Password</value></data>
<data name="Auth_ConfirmPassword" xml:space="preserve"><value>Confirm Password</value></data>
<data name="Auth_RememberMe" xml:space="preserve"><value>Remember me</value></data>
<data name="Auth_ForgotPassword" xml:space="preserve"><value>Forgot your password?</value></data>
<data name="Auth_NewToSite" xml:space="preserve"><value>New to our site?</value></data>
<data name="Auth_AlreadyRegistered" xml:space="preserve"><value>Already have an account?</value></data>

<!-- Blog Forms -->
<data name="Blog_SearchPlaceholder" xml:space="preserve"><value>Search articles...</value></data>
<data name="Blog_FilterByCategory" xml:space="preserve"><value>Filter by category</value></data>
<data name="Blog_FilterByTag" xml:space="preserve"><value>Filter by tag</value></data>

<!-- Comment Forms -->
<data name="Comment_Name" xml:space="preserve"><value>Your Name</value></data>
<data name="Comment_Email" xml:space="preserve"><value>Your Email</value></data>
<data name="Comment_Website" xml:space="preserve"><value>Website (optional)</value></data>
<data name="Comment_PostComment" xml:space="preserve"><value>Post Comment</value></data>

<!-- Newsletter Form -->
<data name="Newsletter_Email" xml:space="preserve"><value>Enter your email</value></data>
<data name="Newsletter_Subscribe" xml:space="preserve"><value>Subscribe</value></data>
```

**When to use**:
```csharp
@inject IStringLocalizer<FormResource> FL

<label>@FL["Auth_Email"]</label>
<input placeholder="@FL["Auth_Email"]" />
```

---

### 3. AuthResource (New - For Authentication)

**Use for**: Login/register pages, password reset, account settings

**Required entries**:

```xml
<!-- Login Page -->
<data name="Login_Title" xml:space="preserve"><value>Sign In</value></data>
<data name="Login_Description" xml:space="preserve"><value>Welcome back! Please sign in to your account.</value></data>
<data name="Login_Button" xml:space="preserve"><value>Sign In</value></data>
<data name="Login_NoAccount" xml:space="preserve"><value>Don't have an account?</value></data>
<data name="Login_ForgotPassword" xml:space="preserve"><value>Forgot password?</value></data>
<data name="Login_InvalidCredentials" xml:space="preserve"><value>Invalid email or password.</value></data>

<!-- Register Page -->
<data name="Register_Title" xml:space="preserve"><value>Create Account</value></data>
<data name="Register_Description" xml:space="preserve"><value>Join us today and start your journey.</value></data>
<data name="Register_Button" xml:space="preserve"><value>Create Account</value></data>
<data name="Register_TermsAgree" xml:space="preserve"><value>I agree to the terms and conditions</value></data>
<data name="Register_PasswordMismatch" xml:space="preserve"><value>Passwords do not match.</value></data>
<data name="Register_EmailExists" xml:space="preserve"><value>Email already registered.</value></data>

<!-- Password Reset -->
<data name="PasswordReset_Title" xml:space="preserve"><value>Reset Password</value></data>
<data name="PasswordReset_SendLink" xml:space="preserve"><value>Send Reset Link</value></data>
<data name="PasswordReset_NewPassword" xml:space="preserve"><value>Enter New Password</value></data>
<data name="PasswordReset_Success" xml:space="preserve"><value>Password reset successfully!</value></data>

<!-- Profile -->
<data name="Profile_Title" xml:space="preserve"><value>My Profile</value></data>
<data name="Profile_EditProfile" xml:space="preserve"><value>Edit Profile</value></data>
<data name="Profile_ChangePassword" xml:space="preserve"><value>Change Password</value></data>
<data name="Profile_DeleteAccount" xml:space="preserve"><value>Delete Account</value></data>
```

**When to use**:
```csharp
@inject IStringLocalizer<AuthResource> AL

<h1>@AL["Login_Title"]</h1>
<button>@AL["Login_Button"]</button>
```

---

### 4. ValidationResource (New - For Validation Messages)

**Use for**: Field validation errors, form validation, business rule errors

**Required entries**:

```xml
<!-- Required Field Errors -->
<data name="Val_Required" xml:space="preserve"><value>This field is required.</value></data>
<data name="Val_RequiredField" xml:space="preserve"><value>{0} is required.</value></data>

<!-- Email Validation -->
<data name="Val_InvalidEmail" xml:space="preserve"><value>Please enter a valid email address.</value></data>

<!-- Length Validation -->
<data name="Val_MinLength" xml:space="preserve"><value>Must be at least {0} characters.</value></data>
<data name="Val_MaxLength" xml:space="preserve"><value>Cannot exceed {0} characters.</value></data>

<!-- Pattern Validation -->
<data name="Val_InvalidFormat" xml:space="preserve"><value>Invalid format.</value></data>

<!-- Number Validation -->
<data name="Val_InvalidNumber" xml:space="preserve"><value>Please enter a valid number.</value></data>
<data name="Val_Range" xml:space="preserve"><value>Value must be between {0} and {1}.</value></data>

<!-- Password Validation -->
<data name="Val_PasswordWeak" xml:space="preserve"><value>Password is too weak.</value></data>
<data name="Val_PasswordRequirements" xml:space="preserve"><value>Password must contain uppercase, lowercase, and numbers.</value></data>

<!-- Custom Errors -->
<data name="Val_Duplicate" xml:space="preserve"><value>This {0} already exists.</value></data>
<data name="Val_NotFound" xml:space="preserve"><value>{0} not found.</value></data>
<data name="Val_Unauthorized" xml:space="preserve"><value>You are not authorized to perform this action.</value></data>
```

**When to use**:
```csharp
[Required(ErrorMessageResourceName = "Val_Required", ErrorMessageResourceType = typeof(ValidationResource))]
public string Email { get; set; }

// In code:
ModelState.AddModelError("Name", VL["Val_RequiredField", "Name"]);
```

---

### 5. ErrorResource (New - For Error Pages)

**Use for**: HTTP error pages, exception messages, system errors

**Required entries**:

```xml
<!-- 404 Errors -->
<data name="Error_404_Title" xml:space="preserve"><value>Page Not Found</value></data>
<data name="Error_404_Description" xml:space="preserve"><value>The page you're looking for doesn't exist.</value></data>
<data name="Error_404_GoHome" xml:space="preserve"><value>Go to Homepage</value></data>

<!-- 500 Errors -->
<data name="Error_500_Title" xml:space="preserve"><value>Server Error</value></data>
<data name="Error_500_Description" xml:space="preserve"><value>Something went wrong on our end. Please try again later.</value></data>

<!-- 403 Errors -->
<data name="Error_403_Title" xml:space="preserve"><value>Access Denied</value></data>
<data name="Error_403_Description" xml:space="preserve"><value>You don't have permission to access this resource.</value></data>

<!-- Generic Errors -->
<data name="Error_Generic" xml:space="preserve"><value>An error occurred. Please try again.</value></data>
<data name="Error_Timeout" xml:space="preserve"><value>The request took too long. Please try again.</value></data>
<data name="Error_NoConnection" xml:space="preserve"><value>No internet connection. Please check your network.</value></data>

<!-- Operation Errors -->
<data name="Error_DeleteFailed" xml:space="preserve"><value>Failed to delete {0}.</value></data>
<data name="Error_CreateFailed" xml:space="preserve"><value>Failed to create {0}.</value></data>
<data name="Error_UpdateFailed" xml:space="preserve"><value>Failed to update {0}.</value></data>
```

**When to use**:
```csharp
// In error views:
@inject IStringLocalizer<ErrorResource> EL

<h1>@EL["Error_404_Title"]</h1>

// In controllers:
throw new InvalidOperationException(EL["Error_DeleteFailed", "Post"]);
```

---

## Implementation Guide

### Step 1: Create New Resource Files

Create these files in `Resources/` folder:

**FormResource.resx** (English):
```xml
<?xml version="1.0" encoding="utf-8"?>
<root>
  <!-- [Content from above] -->
</root>
```

**FormResource.ar.resx** (Arabic):
```xml
<?xml version="1.0" encoding="utf-8"?>
<root>
  <!-- Arabic translations of each entry -->
</root>
```

Repeat for: `AuthResource`, `ValidationResource`, `ErrorResource`

### Step 2: Register in DI Container

Update `Program.cs`:

```csharp
builder.Services.AddLocalization(opts => opts.ResourcesPath = "Resources");

// Make all resources available
var supportedCultures = new[] { new CultureInfo("en"), new CultureInfo("ar") };
builder.Services.Configure<RequestLocalizationOptions>(opts =>
{
    opts.DefaultRequestCulture = new RequestCulture("en");
    opts.SupportedCultures = supportedCultures;
    opts.SupportedUICultures = supportedCultures;
});
```

### Step 3: Inject in Views

Update `_ViewImports.cshtml`:

```csharp
@inject IStringLocalizer<SharedResource> L
@inject IStringLocalizer<FormResource> FL
@inject IStringLocalizer<AuthResource> AL
@inject IStringLocalizer<ValidationResource> VL
@inject IStringLocalizer<ErrorResource> EL
```

### Step 4: Use in Views

```html
<!-- Form Labels -->
<label>@FL["Auth_Email"]</label>

<!-- Validation Messages -->
<span>@VL["Val_Required"]</span>

<!-- Auth Messages -->
<h1>@AL["Login_Title"]</h1>

<!-- Error Messages -->
<h1>@EL["Error_404_Title"]</h1>
```

### Step 5: Use in Controllers

```csharp
public class AccountController : Controller
{
    private readonly IStringLocalizer<AuthResource> _localizer;

    public AccountController(IStringLocalizer<AuthResource> localizer)
    {
        _localizer = localizer;
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("", _localizer["Login_InvalidCredentials"]);
            return View(model);
        }
        // ...
    }
}
```

---

## Forms Needing Localization

### High Priority (Currently Missing)

| Form | Location | Strings Needed |
|------|----------|----------------|
| Login | `/Account/Login` | Title, labels, button, errors |
| Register | `/Account/Register` | Title, labels, button, terms |
| Password Reset | `/Account/PasswordReset` | Title, labels, button |
| Contact Form | `/Contact/Index` | ✓ Partially done |
| Blog Comments | `/Blog/Details` | Name, email, message |
| Newsletter | `/Home/Index` | ✓ Partially done |
| Search | Multiple | Placeholder, filters |
| Profile Settings | `/Account/Settings` | Labels, buttons |

### Validation Messages Needed

| Type | Current | Needed |
|------|---------|--------|
| Required | ❌ | "This field is required" |
| Email | ❌ | "Invalid email address" |
| Length | ❌ | "Must be X-Y characters" |
| Password | ❌ | "Password requirements" |
| Unique | ❌ | "Email already exists" |
| Custom | ❌ | Business rule errors |

---

## Best Practices

### ✓ DO

```csharp
// ✓ Use consistent naming: Feature_Element_Context
<data name="Blog_SearchPlaceholder" />
<data name="Blog_FilterByTag" />
<data name="Blog_EmptyState" />

// ✓ Keep strings focused
<data name="Auth_Email" xml:space="preserve"><value>Email Address</value></data>

// ✓ Use parameters for dynamic content
<data name="Val_MinLength" xml:space="preserve"><value>Must be at least {0} characters</value></data>

// ✓ Group related strings
<!-- Contact Form -->
<data name="Contact_FormTitle" />
<data name="Contact_FullName" />
<data name="Contact_Message" />
```

### ❌ DON'T

```csharp
// ❌ Generic names that don't indicate purpose
<data name="Label1" />
<data name="Label2" />

// ❌ Long, complex strings
<data name="Msg1" xml:space="preserve">
    <value>We need you to enter your email address so we can send you a confirmation link</value>
</data>

// ❌ Mixing unrelated strings
<data name="HomePage_ContactForm_BlogSearch_Text" />

// ❌ Duplicate strings across files
<!-- In SharedResource -->
<data name="Submit" xml:space="preserve"><value>Submit</value></data>
<!-- In FormResource -->
<data name="Submit" xml:space="preserve"><value>Submit</value></data>
```

---

## Naming Convention

### Pattern

`[Feature]_[Element]_[Context]`

### Examples

```
Navigation:
  Nav_Home
  Nav_Blog
  Nav_Contact

Forms:
  Contact_FormTitle
  Contact_FullName
  Contact_Message

Authentication:
  Auth_LoginTitle
  Auth_PasswordLabel
  Auth_RememberMe

Validation:
  Val_Required
  Val_InvalidEmail
  Val_MinLength

Errors:
  Error_404_Title
  Error_500_Description
```

---

## Testing Localization

### Manual Testing

1. Switch language via `/Culture/SetCulture?culture=ar`
2. Verify all strings display correctly
3. Check RTL layout for Arabic
4. Test form submission and validation messages

### Unit Testing

```csharp
[Fact]
public void Login_FormTitle_ReturnsLocalizedString()
{
    var localizer = new ResourceManager("AuthResource", Assembly.GetExecutingAssembly());
    var result = localizer.GetString("Login_Title");
    
    Assert.NotNull(result);
    Assert.NotEmpty(result);
}
```

---

## Migration from Monolithic to Modular

### Current State
- `SharedResource.resx` (All strings in one file)

### Target State
```
Resources/
├── SharedResource.resx           ← Keep as is
├── SharedResource.ar.resx        ← Keep as is
├── FormResource.resx             ← NEW
├── FormResource.ar.resx          ← NEW
├── AuthResource.resx             ← NEW
├── AuthResource.ar.resx          ← NEW
├── ValidationResource.resx       ← NEW
├── ValidationResource.ar.resx    ← NEW
├── ErrorResource.resx            ← NEW
└── ErrorResource.ar.resx         ← NEW
```

### Migration Steps

1. **Phase 1**: Create `FormResource` (form labels, placeholders)
2. **Phase 2**: Create `AuthResource` (login, register, password)
3. **Phase 3**: Create `ValidationResource` (validation messages)
4. **Phase 4**: Create `ErrorResource` (error pages)
5. **Phase 5**: Update all views and controllers

---

## Common Patterns

### Form with Validation

```csharp
// View
@inject IStringLocalizer<FormResource> FL
@inject IStringLocalizer<ValidationResource> VL

<div class="form-group">
    <label asp-for="Email">@FL["Auth_Email"]</label>
    <input asp-for="Email" />
    <span asp-validation-for="Email" class="error">
        @VL["Val_InvalidEmail"]
    </span>
</div>

// Model
[Required(ErrorMessageResourceName = "Val_Required", 
          ErrorMessageResourceType = typeof(ValidationResource))]
[EmailAddress(ErrorMessageResourceName = "Val_InvalidEmail",
              ErrorMessageResourceType = typeof(ValidationResource))]
public string Email { get; set; }
```

### Error Handling

```csharp
// Controller
catch (ArgumentException ex)
{
    TempData["Error"] = _localizer["Error_DeleteFailed", "Post"];
    return RedirectToAction(nameof(Index));
}

// View
@if (TempData.ContainsKey("Error"))
{
    <div class="alert alert-error">
        @TempData["Error"]
    </div>
}
```

### Conditional Localization

```csharp
// Based on current culture
var culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
var isArabic = culture == "ar";

// In Razor
@if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar")
{
    <div dir="rtl">
        @L["Nav_Home"]
    </div>
}
```

---

## Troubleshooting

### String Not Found

**Issue**: Localizer returns key name instead of translated string

**Solution**:
1. Check `.resx` file encoding (must be UTF-8)
2. Verify key name matches exactly (case-sensitive)
3. Ensure resource is registered in `Program.cs`
4. Clear browser cache and rebuild

### Wrong Culture Used

**Issue**: English strings showing when Arabic selected

**Solution**:
```csharp
// Check current culture
var culture = CultureInfo.CurrentCulture;
var uiCulture = CultureInfo.CurrentUICulture;

// Force culture
CultureInfo.CurrentCulture = new CultureInfo("ar");
CultureInfo.CurrentUICulture = new CultureInfo("ar");
```

### RTL Layout Issues

**Issue**: Arabic text displays but layout isn't RTL

**Solution**:
```html
<!-- Add dir attribute based on culture -->
<div dir="@(CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? "rtl" : "ltr")">
    @L["Content"]
</div>

<!-- Or in CSS -->
html[lang="ar"] {
    direction: rtl;
    text-align: right;
}
```

---

## Performance Considerations

- Resource files are cached in memory after first access
- Switching cultures uses cookies (default expiry: 1 year)
- No database queries needed for localization
- String formatting `{0}, {1}` is performant

## Future Enhancements

- [ ] Database-driven strings (for user-edited content)
- [ ] Support for more languages (French, Spanish)
- [ ] Automatic pluralization rules
- [ ] Date/time/number localization
- [ ] Admin UI for managing strings
