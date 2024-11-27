using HoaPortalApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HoaPortalApp.Persistence
{
    public class ApplicationDbContext : AuditableDbContext
    {
        public DbSet<Document> Documents { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<OwnerResidence> OwnerResidences { get; set;}

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
