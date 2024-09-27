using HoaPortalApp.Domain.Entities;
using HoaPortalApp.Identity.Configurations;
using HoaPortalApp.Identity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HoaPortalApp.Identity
{
    public class IdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        DbSet<User> _users { get; set; }
        DbSet<HOAAdmin> _admins { get; set; }
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }


}

