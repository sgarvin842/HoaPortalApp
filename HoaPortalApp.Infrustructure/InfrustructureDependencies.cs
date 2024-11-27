using HoaPortalApp.Application.Contracts.User;
using HoaPortalApp.Identity.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HoaPortalApp.Infrustructure
{
    public static class InfrustructureDependencies
    {
        public static IServiceCollection AddInfrustructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
