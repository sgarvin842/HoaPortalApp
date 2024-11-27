using HoaPortalApp.Application.Contracts.Identity;
using HoaPortalApp.Application.Contracts.User;
using HoaPortalApp.Application.Models;
using HoaPortalApp.Application.Models.Identity;
using HoaPortalApp.Identity.Helpers;
using HoaPortalApp.Identity.Helpers.Filters;
using HoaPortalApp.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HoaPortalApp.Identity
{
    public static class IdentityDependencies
    {
        public static IServiceCollection AddIdentityDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            services.AddDbContext<IdentityDbContext>(options =>
      options.UseSqlServer(configuration.GetConnectionString("IdentityConnection"),
      b => b.MigrationsAssembly(typeof(IdentityDbContext).Assembly.FullName)),
      ServiceLifetime.Scoped);


            services.AddScoped<IEmailsService, EmailsService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IUser, CurrentUser>();
            services.AddScoped<IRoleService, RoleService>();


            var emailSettings = new EmailSettings();
            configuration.GetSection(nameof(emailSettings)).Bind(emailSettings);

            services.AddSingleton(emailSettings);

            ////////////////////////////////////////////////////////Authorization//////////////////////////////////////////
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();//one instance
            services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
            services.Configure<SecurityStampValidatorOptions>(options =>
            {
                options.ValidationInterval = TimeSpan.Zero;
            });
            ////////////////////////////////////////////////////////END//////////////////////////////////////////////////////
            IConfigurationSection _IConfigurationSection = configuration.GetSection("IdentityDefaultOptions");
            services.Configure<DefaultIdentityOptions>(_IConfigurationSection);
            var _DefaultIdentityOptions = _IConfigurationSection.Get<DefaultIdentityOptions>();
            AddIdentityOptions.SetOptions(services, _DefaultIdentityOptions);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(async options =>
            {
                var tcs = new TaskCompletionSource<object>();
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"])),
                    ClockSkew = TimeSpan.Zero,
                    RequireExpirationTime = true
                };
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var token = context.Request.Headers["Authorization"].ToString();
                        Console.WriteLine("Received Token: " + token);
                        return Task.CompletedTask;
                    },
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine($"Authentication failed: {context.Exception.InnerException}");
                        context.Response.Headers.Add("Token-Expired", "true");  // Optional header to detect token issues
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        Console.WriteLine("Token validated successfully. UserId: " +
                            context.Principal?.Claims.FirstOrDefault(c => c.Type == "sub")?.Value);
                        return Task.CompletedTask;
                    },
                    OnChallenge = context =>
                    {
                        Console.WriteLine("OnChallenge triggered. Authentication failed.");
                        return Task.CompletedTask;
                    }
                };
            });
            return services;
        }
    }
}
