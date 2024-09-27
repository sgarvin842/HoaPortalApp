using HoaPortalApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HoaPortalApp.Persistence
{
    public class ApplicationDbContext : AuditableDbContext
    {
        DbSet<Document> _documents { get; set; }
        DbSet<Event> _events { get; set; }
        DbSet<Payment> _payment { get; set; }
        DbSet<Report> reports { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        }



    }
}
