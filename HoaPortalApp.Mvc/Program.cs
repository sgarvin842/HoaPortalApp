using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });

// Configure HttpClient with JWT handling
builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:44351/"); // API base URL
})
.AddHttpMessageHandler<JwtAuthorizationHandler>();


// Inject IHttpContextAccessor to use it in JwtAuthorizationHandler
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Add JwtAuthorizationHandler as a transient service
builder.Services.AddTransient<JwtAuthorizationHandler>();

// Configure authentication using cookies
builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
})
 .AddJwtBearer(options =>
 {
     var jwtSettings = builder.Configuration.GetSection("Jwt");
     var key = jwtSettings.GetSection("Key").Value;
     var issuer = jwtSettings.GetSection("Issuer").Value;

     options.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuer = true,
         ValidateAudience = false,
         ValidateLifetime = true,
         ValidateIssuerSigningKey = true,
         ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"])),

     };
 });

// Configure authorization with a default policy
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.Use(async (context, next) =>
{
    var token = context.Request.Cookies["JwtToken"];

    if (!string.IsNullOrEmpty(token) &&
        !context.Request.Headers.ContainsKey("Authorization"))
    {
        context.Request.Headers.Add("Authorization", "Bearer " + token);
    }

    await next();
});
app.UseAuthentication(); // Enable authentication
app.UseAuthorization();  // Enable authorization

// Define routes for the application
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "Payments",
    pattern: "{controller=Home}/{action=Payments}/{id?}");

app.MapControllerRoute(
    name: "ContactInfo",
    pattern: "{controller=Home}/{action=ContactInfo}/{id?}");

app.MapControllerRoute(
    name: "MyItems",
    pattern: "{controller=Home}/{action=MyItems}/{id?}");

app.MapControllerRoute(
    name: "CalendarAndEvents",
    pattern: "{controller=Home}/{action=CalendarAndEvents}/{id?}");

app.MapControllerRoute(
    name: "Directory",
    pattern: "{controller=Home}/{action=Directory}/{id?}");

app.MapControllerRoute(
    name: "Documents",
    pattern: "{controller=Home}/{action=Documents}/{id?}");

app.MapControllerRoute(
    name: "Login",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.MapControllerRoute(
    name: "Logout",
    pattern: "{controller=Home}/{action=Logout}/{id?}");

app.Run();
