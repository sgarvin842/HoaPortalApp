using HoaPortalApp.Api.Configuration.Extensions.Swagger;
using HoaPortalApp.Application;
using HoaPortalApp.Application.Middleware;
using HoaPortalApp.Identity;
using HoaPortalApp.Infrustructure;
using HoaPortalApp.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
var jwtSettings = builder.Configuration.GetSection("JwtSettings");


builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser()
        .Build();
});

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocumentation();
//Serilog
Log.Logger = new LoggerConfiguration()
              .ReadFrom.Configuration(builder.Configuration).CreateLogger();
builder.Services.AddSerilog();

builder.Services.AddCors(o =>
{
    o.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

//Register Dependencies
builder.Services.AddApplicationDependencies(builder.Configuration)
                .AddInfrustructureDependencies(builder.Configuration)
                .AddPersistenceDependencies(builder.Configuration)
                .AddIdentityDependencies(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerDocumentation();
}

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();


////////////////////////////////////////////////////////Localizer with JSON//////////////////////////////////////
var supportedCultures = new[] { "en-US", "ar-EG", "de-DE" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);
localizationOptions.ApplyCurrentCultureToResponseHeaders = true;
app.UseRequestLocalization(localizationOptions);


app.UseRouting();
////////////////////////////////////////////////////////END//////////////////////////////////////////////////////
app.UseAuthentication();
app.UseAuthorization();


app.Use(async (context, next) =>
{
    if (context.Request.Headers.ContainsKey("Authorization"))
    {
        var token = context.Request.Headers["Authorization"];
        Console.WriteLine("Authorization Header: " + token);
    }
    else
    {
        Console.WriteLine("Authorization header not present.");
    }

    await next.Invoke();
});

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
