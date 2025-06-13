using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Workspace> Workspaces { get; set; }

        public DbSet<Amenity> Amenities { get; set; }

        public DbSet<Capacity> Capacities { get; set; }

        public DbSet<RoomAvailability> RoomAvailabilities { get; set; }

        public DbSet<MyImage> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Booking>()
                .HasOne(b => b.Workspace)
                .WithMany(w => w.Bookings)
                .HasForeignKey(b => b.WorkspaceId);

            modelBuilder
                .Entity<Workspace>()
                .HasMany(w => w.Amenities)
                .WithOne(a => a.Workspace)
                .HasForeignKey(a => a.WorkspaceId);

            modelBuilder
                .Entity<Workspace>()
                .HasMany(w => w.CapacityOptions)
                .WithOne(c => c.Workspace)
                .HasForeignKey(c => c.WorkspaceId);

            modelBuilder
                .Entity<Capacity>()
                .HasMany(c => c.RoomAvailabilities)
                .WithOne(r => r.Capacity)
                .HasForeignKey(r => r.CapacityId);

            modelBuilder
                .Entity<Workspace>()
                .HasMany(i => i.Images)
                .WithOne(w => w.Workspace)
                .HasForeignKey(i => i.WorkspaceId);

            DataSeeder.Seed(modelBuilder);
        }
    }
}
