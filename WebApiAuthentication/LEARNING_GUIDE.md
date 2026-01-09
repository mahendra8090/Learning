# Authentication and Authorization With ASP.NET Core Identity (.NET 10)

## Web Security Under the Hood for Web Applications

### 1. Security Overview
- Understanding web application security threats
- OWASP Top 10 vulnerabilities
- Defense in depth approach
- Security principles (least privilege, fail-safe defaults)
- Common attack vectors (XSS, CSRF, SQL injection, man-in-the-middle)
- Security vs usability trade-offs

### 2. Authentication and Authorization Flow
- Authentication (proving identity)
- Authorization (granting access)
- Complete authentication flow diagram
- HTTP request/response cycle
- Credential validation process
- Session establishment
- Security token generation and validation

### 3. ASP.NET Core Basics
- ASP.NET Core architecture overview
- Middleware pipeline
- Dependency injection in ASP.NET Core
- Startup configuration (Program.cs)
- Configuration and secrets management
- Environment-specific settings

### 4. Security Context in ASP.NET Core
- ClaimsPrincipal and ClaimsIdentity
- User object in controllers
- Claims-based identity model
- Security context propagation through request pipeline
- Accessing user information in application code
- Thread safety of security context

### 5. Anonymous Identity
- DefaultIdentity behavior
- IsAuthenticated property
- Anonymous vs Unauthenticated requests
- AllowAnonymous attribute
- Default route behavior for anonymous users

### 6. Create Login Page
- Login page UI/UX design
- Form submission methods (POST)
- Remember me functionality
- Return URL for post-login redirection
- Error messaging for failed login
- Client-side validation considerations

### 7. Generate Cookie with Cookie Authentication Handler
- CookieAuthenticationOptions configuration
- Cookie authentication handler setup in middleware
- Cookie generation process
- Cookie encryption and signing
- Secure and HttpOnly flags
- SameSite cookie attribute (CSRF protection)

### 8. Read Cookie and Authentication Middleware
- Cookie authentication middleware
- Cookie deserialization
- ClaimsPrincipal creation from cookie data
- Middleware ordering importance
- Cookie validation and tampering detection
- Cookie expiration handling

### 9. Authorization Architecture and Flow
- Authorization policies and requirements
- Authorization handlers
- Authorization service
- Policy-based authorization
- Role-based authorization
- Resource-based authorization

### 10. Simple Policy Based Authorization
- Creating authorization policies
- Claim-based policies
- Role-based policy construction
- Applying policies with [Authorize] attribute
- Policy evaluation in authorization middleware
- Default authorization policy

### 11. Login and Logout Partial View
- Login form structure
- Form helper methods
- Model binding for credentials
- Logout implementation
- Session cleanup
- Redirect after logout
- User identity display in navigation

### 12. Custom Policy Based Authorization
- Custom authorization requirements
- Custom authorization handlers
- Complex authorization logic
- Context-based authorization
- Dynamic policy evaluation
- Testing custom policies

### 13. Cookie Lifetime and Browser Session
- Persistent vs session cookies
- Absolute expiration time
- Sliding expiration
- Cookie refresh behavior
- Browser session management
- Session vs persistent authentication
- Logout cookie clearing

---

## Secure WebApi

### 1. Cookie vs Token and Use Cases
- Cookie-based authentication limitations for APIs
- Token-based authentication advantages
- Stateless vs stateful authentication
- CORS considerations with cookies
- Mobile and SPA client requirements
- Hybrid approaches (cookie + token)

### 2. Create and Consume a WebApi Endpoint
- RESTful API principles
- HTTP methods and status codes
- Request and response formats (JSON)
- API versioning approaches
- Content negotiation
- Error response handling

### 3. What is JWT Token
- JWT structure (Header.Payload.Signature)
- Token composition and components
- Payload claims
- Token encoding (Base64URL)
- JWT vs opaque tokens
- JWT use cases and limitations

### 4. The Typical JWT Flow
- Token request with credentials
- Token generation and signing
- Token storage on client
- Token transmission in HTTP headers (Authorization Bearer)
- Token validation on server
- Token refresh flow
- Token expiration and renewal

### 5. Generate JWT Token with JWT Token Handler
- JwtSecurityTokenHandler configuration
- Token creation with claims
- Signing credentials setup
- Key management and rotation
- Token lifetime configuration
- Custom claim inclusion

### 6. Read JWT Token with Authentication Handler and Middleware
- JwtBearerAuthenticationOptions configuration
- Token validation parameters
- Signature validation
- Issuer and audience validation
- Claim mapping
- Token expiration checking
- Invalid token handling

### 7. Consume the Endpoint Protected with JWT Token
- HTTP client setup with token headers
- Bearer token transmission
- Authorization header format
- Handling 401 Unauthorized responses
- Token refresh handling
- Retry logic for expired tokens

### 8. Store and Reuse Token in Session
- Client-side token storage strategies
- Local storage vs session storage security considerations
- Token storage in HttpContext session
- Token reuse across multiple requests
- Token lifecycle management
- Clearing token on logout

### 9. Apply Policy to WebApi Endpoint
- [Authorize] attribute on API controllers/actions
- Policy-based authorization on endpoints
- Role-based authorization on API methods
- Custom policy attributes
- Per-action vs per-controller authorization
- Cross-origin policy considerations

---

## ASP.NET Core Identity

### 1. Three Essential Parts of Identity
- User Management (UserManager)
- Role Management (RoleManager)
- Sign-In Management (SignInManager)
- Core functionality of each component
- Integration points
- Extension possibilities

### 2. Install Nuget Package for Working with Identity
- Microsoft.AspNetCore.Identity package
- Microsoft.AspNetCore.Identity.EntityFrameworkCore package
- Microsoft.EntityFrameworkCore packages
- Database provider packages (SQL Server, SQLite, etc.)
- Version compatibility with .NET 10
- Dependency resolution

### 3. Create Database for Identity
- Database schema creation with Entity Framework Core
- Identity tables structure
- Migrations for database updates
- Initial migration setup
- Database initialization code
- Local vs production database configuration

### 4. Configure the WebApp to Use Identity
- AddIdentity() service registration
- AddDefaultTokenProviders() setup
- IdentityOptions configuration
- Password policy settings
- Lockout policy configuration
- User-related options customization

### 5. Core Classes of Identity
- IdentityUser base class and properties
- IdentityRole class structure
- IdentityUserRole relationship
- IdentityUserClaim structure
- IdentityUserLogin for external providers
- Custom user class extension

### 6. User Registration Workflow
- Registration form design
- Password requirements validation
- Email validation
- Duplicate user checking
- User creation process
- Post-registration actions

### 7. User Registration
- Registration page implementation
- RegisterViewModel creation
- UserManager.CreateAsync() method
- Password hashing
- Error handling during registration
- Success confirmation flow
- Email confirmation requirement integration

### 8. User Login
- Login page and form
- LoginViewModel structure
- Credential validation
- SignInManager.PasswordSignInAsync() method
- Lockout handling
- Successful login redirect
- Failed login error messages

### 9. Email Confirmation Flow
- Why email confirmation is important
- Confirmation token generation
- Email sending mechanism
- Token validation process
- Confirmation link in email
- User confirmation status tracking
- Resend confirmation email functionality

### 10. Email Confirmation Dry Run
- Testing email confirmation without SMTP
- Using IEmailSender for abstraction
- Logging token to console for testing
- Email confirmation token structure
- Testing workflow validation
- Development vs production setup

### 11. Confirm Email Page
- Email confirmation page implementation
- Confirmation link handling
- UserManager.ConfirmEmailAsync() method
- Success and failure messages
- Post-confirmation actions
- Error handling for invalid tokens
- Expired token handling

### 12. Send Email
- IEmailSender interface implementation
- SMTP configuration
- MailKit or System.Net.Mail usage
- Email template design
- Async email sending
- Exception handling
- Email delivery reliability

### 13. Refactor Email Sending Code
- Abstraction layers for email service
- Dependency injection of email sender
- Configuration management
- Testing email functionality
- Error logging and retry logic
- Template management
- Rate limiting considerations

### 14. SignOut
- SignOut action implementation
- SignInManager.SignOutAsync() method
- Cookie clearing
- Session cleanup
- Redirect after logout
- Logout confirmation messages
- Security context cleanup

### 15. Collecting More User Info with IdentityUser Schema Change
- Extending IdentityUser class
- Custom properties (phone, address, etc.)
- Migration of schema changes
- Data annotation attributes
- Validation rules for custom properties
- Displaying custom fields in UI

### 16. Collecting More User Info with Claims
- Claims-based approach to user information
- Claim types and values
- UserManager.AddClaimAsync() method
- Claim retrieval and usage
- Claims transformation
- Advantages over schema extension

### 17. Roles
- Role creation and management
- RoleManager usage
- Assigning users to roles
- Role-based authorization
- Multiple roles per user
- Role hierarchy considerations
- Dynamic role management

### 18. Create a User Profile Page
- Profile information display
- Edit profile functionality
- Password change capability
- Email change and verification
- Profile picture upload
- Personal information management
- Profile security considerations

---

## ASP.NET Core Identity MFA

### 1. What is MFA
- Multi-factor authentication overview
- Security benefits of MFA
- Common MFA factors (something you know, have, are)
- MFA adoption trends
- User experience impact
- Recovery codes and backup options

### 2. How 2FA Works Through Email
- Email-based two-factor authentication flow
- Verification code generation
- Email delivery mechanism
- Code validation process
- Code expiration handling
- User confirmation after email verification

### 3. Implement Email 2FA
- UserManager.GenerateTwoFactorTokenAsync() method
- Email token provider setup
- Sending OTP via email
- Two-factor code input page
- Code verification with SignInManager.TwoFactorSignInAsync()
- Remember machine option
- Fallback options

### 4. How 2FA with Authenticator App Works
- TOTP (Time-based One-Time Password) algorithm
- QR code generation for app setup
- Authenticator app scanning
- Time synchronization requirements
- Code generation and expiration
- Backup codes generation

### 5. Implement Authenticator MFA Setup Manual
- GetAuthenticatorUri() method
- Manual entry key display
- UserManager.ResetAuthenticatorKeyAsync()
- UserManager.SetTwoFactorEnabledAsync()
- Backup codes generation
- Verification of authenticator setup

### 6. Implement Authenticator MFA Code Checking
- TOTP code input page
- Verifying authenticator tokens
- SignInManager.TwoFactorAuthenticatorSignInAsync() method
- Backup code validation
- Code expiration handling
- Failed attempt tracking

### 7. Use QR Code for MFA Setup
- QR code generation library (QRCoder, ZXing.Net)
- Encoding authenticator URI as QR code
- Displaying QR code in setup page
- Client-side QR code scanning
- Mobile authenticator app integration
- Alternative manual entry fallback

---

## External Authentication Providers

### 1. Overview of Login with Social Media Accounts
- External authentication benefits
- Delegated authentication concept
- Popular social providers (Facebook, Google, Microsoft, GitHub)
- OAuth and OpenID Connect protocols
- Federated identity management
- User account linking

### 2. Setup App Account in Facebook
- Facebook Developer Console registration
- Creating Facebook App
- Configuring app settings
- Generating API credentials (App ID, App Secret)
- Setting authorized redirect URIs
- Testing app configuration
- Privacy and permissions scoping

### 3. How OAuth Really Works
- OAuth 2.0 flow (Authorization Code Grant)
- Client authentication
- Authorization request and response
- Access token acquisition
- Token refresh mechanism
- Scope and permissions
- Security considerations (CSRF protection, state parameter)

### 4. Delegate Login to Facebook
- Microsoft.AspNetCore.Authentication.Facebook package
- AddFacebook() service registration
- FacebookOptions configuration
- ClientId and ClientSecret setup
- Scope definition
- Fields mapping
- Challenge authentication

### 5. Implement Callback Controller
- Callback URI configuration in Facebook app
- RemoteError handling
- ExternalLoginInfo retrieval
- Creating user from external login
- Linking external logins to existing users
- User creation on first external login
- Email confirmation for external accounts

---

## Best Practices Summary

### Security Best Practices
- Always use HTTPS in production
- Never log sensitive information
- Implement rate limiting for login attempts
- Use strong password policies
- Enable MFA for critical accounts
- Validate and sanitize all inputs
- Implement CSRF protection
- Use secure headers (CSP, X-Frame-Options, etc.)
- Keep frameworks and packages updated

### Identity Management
- Use built-in Identity system instead of custom implementation
- Implement email confirmation
- Enable account lockout after failed attempts
- Use strong password hashing (Identity uses PBKDF2 by default)
- Implement MFA for sensitive operations
- Properly handle password reset flows
- Audit user activities

### Token Management
- Keep JWT secret keys secure
- Implement short token expiration times
- Use refresh tokens for long-lived sessions
- Rotate signing keys regularly
- Validate token expiration
- Implement token revocation mechanism

### Authorization
- Follow principle of least privilege
- Use policy-based authorization
- Implement custom authorization handlers for complex logic
- Test authorization rules thoroughly
- Use role-based authorization for simpler scenarios
- Audit authorization decisions

### API Security
- Use API keys or tokens for API access
- Implement rate limiting
- Version your APIs
- Validate all API inputs
- Return appropriate HTTP status codes
- Log API access and failures
- Implement CORS properly

---

## Common Implementation Patterns

### Authentication Patterns
- Cookie-based for traditional web applications
- JWT for APIs and SPAs
- Hybrid approach for applications with both web and API components
- Multi-tenant authentication considerations
- Passwordless authentication options

### Authorization Patterns
- Role-based access control (RBAC)
- Attribute-based access control (ABAC)
- Claim-based authorization
- Dynamic authorization policies
- Resource-based authorization

### External Authentication Patterns
- Single sign-on (SSO)
- Account linking to external providers
- Federated identity management
- Just-in-time user provisioning

---

## Testing Authentication and Authorization

### Unit Testing
- Testing custom authorization handlers
- Mocking UserManager and SignInManager
- Testing policy evaluation
- Claim-based testing

### Integration Testing
- Testing complete authentication flows
- Testing authorization on protected endpoints
- Testing external authentication flows
- Database integration testing

### Security Testing
- Testing for common vulnerabilities
- Load testing authentication system
- Testing rate limiting
- Testing token expiration

---

## Troubleshooting Common Issues

### Authentication Issues
- Cookies not persisting
- Token validation failures
- Claims not appearing in token
- External authentication failures
- Redirect loops

### Authorization Issues
- Policies not working as expected
- Role-based authorization failures
- Claims not matching policy requirements
- Authorization caching issues

### Database Issues
- Migration failures
- Schema mismatch
- Connection string problems
- Entity mapping issues

---

## Resources for Further Learning

- Microsoft Docs: ASP.NET Core Security
- Microsoft Docs: ASP.NET Core Identity
- Microsoft Docs: Authorization in ASP.NET Core
- OWASP Web Security Testing Guide
- OAuth 2.0 and OpenID Connect specifications
- JWT.io documentation
- "ASP.NET Core Security" book
- Security Cheat Sheet for ASP.NET Core

---

## Project Structure Recommendations

```
WebApiAuthentication/
??? Controllers/
?   ??? AccountController.cs
?   ??? AuthenticationController.cs
?   ??? UserController.cs
??? Models/
?   ??? ViewModels/
?   ?   ??? LoginViewModel.cs
?   ?   ??? RegisterViewModel.cs
?   ?   ??? ...
?   ??? Entities/
?       ??? ApplicationUser.cs
??? Services/
?   ??? IEmailSender.cs
?   ??? EmailSender.cs
?   ??? ...
??? Data/
?   ??? ApplicationDbContext.cs
??? Views/
?   ??? Account/
?       ??? Login.cshtml
?       ??? Register.cshtml
?       ??? ...
??? Program.cs
??? appsettings.json
```

---

## Configuration Example (.NET 10)

Key configuration points in `Program.cs`:
- Identity service registration
- Authentication middleware setup
- Authorization policy configuration
- External authentication setup
- Database context configuration
- Email service registration

---

## Security Checklist

- [ ] HTTPS enforced in production
- [ ] Secure password policy configured
- [ ] Account lockout enabled
- [ ] Email confirmation required
- [ ] MFA available for users
- [ ] CSRF protection enabled
- [ ] XSS protection headers set
- [ ] SQL injection prevention (EF Core parameterized queries)
- [ ] Rate limiting implemented
- [ ] Audit logging configured
- [ ] Security headers configured
- [ ] Token expiration properly implemented
- [ ] Sensitive data not logged
- [ ] Secrets not in code/config files
- [ ] Regular security updates applied
