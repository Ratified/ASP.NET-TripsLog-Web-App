using Microsoft.EntityFrameworkCore;
namespace TripLog.Models
{
    public class TripContext: DbContext
    {
        public DbSet<Trip> Trips { get; set; }

        public TripContext(DbContextOptions<TripContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>()
                .HasMany(t => t.ThingsToDo)
                .WithOne(td => td.Trip)
                .HasForeignKey(td => td.TripId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
