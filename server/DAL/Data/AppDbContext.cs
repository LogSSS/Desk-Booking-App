using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Shared.Enums;

namespace DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingsList> BookingsLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<BookingsList>()
                .HasData(
                    new BookingsList { Id = 1, Name = "Booking List 1" },
                    new BookingsList { Id = 2, Name = "Booking List 2" }
                );

            modelBuilder
                .Entity<Booking>()
                .HasData(
                    new Booking
                    {
                        Id = 1,
                        Name = "Alice",
                        Email = "alice@example.com",
                        WorkspaceType = Workspace.OpenSpace,
                        StartDate = DateTime.SpecifyKind(
                            new DateTime(2025, 5, 25, 10, 0, 0),
                            DateTimeKind.Utc
                        ),
                        EndDate = DateTime.SpecifyKind(
                            new DateTime(2025, 5, 26, 23, 0, 0),
                            DateTimeKind.Utc
                        ),
                        CreatedAt = DateTime.SpecifyKind(
                            new DateTime(2025, 6, 1, 12, 0, 0),
                            DateTimeKind.Utc
                        ),
                        Status = Status.Active,
                        BookingsListId = 1,
                    },
                    new Booking
                    {
                        Id = 2,
                        Name = "Bob",
                        Email = "bob@example.com",
                        WorkspaceType = Workspace.OpenSpace,
                        StartDate = DateTime.SpecifyKind(
                            new DateTime(2025, 5, 27, 10, 0, 0),
                            DateTimeKind.Utc
                        ),
                        EndDate = DateTime.SpecifyKind(
                            new DateTime(2025, 5, 28, 23, 0, 0),
                            DateTimeKind.Utc
                        ),
                        CreatedAt = DateTime.SpecifyKind(
                            new DateTime(2025, 6, 1, 12, 0, 0),
                            DateTimeKind.Utc
                        ),
                        Status = Status.Active,
                        BookingsListId = 1,
                    },
                    new Booking
                    {
                        Id = 3,
                        Name = "Charlie",
                        Email = "charlie@example.com",
                        WorkspaceType = Workspace.PrivateRooms,
                        StartDate = DateTime.SpecifyKind(
                            new DateTime(2025, 5, 25, 10, 0, 0),
                            DateTimeKind.Utc
                        ),
                        EndDate = DateTime.SpecifyKind(
                            new DateTime(2025, 5, 26, 23, 0, 0),
                            DateTimeKind.Utc
                        ),
                        CreatedAt = DateTime.SpecifyKind(
                            new DateTime(2025, 6, 1, 12, 0, 0),
                            DateTimeKind.Utc
                        ),
                        Status = Status.Active,
                        BookingsListId = 1,
                    },
                    new Booking
                    {
                        Id = 4,
                        Name = "Diana",
                        Email = "diana@example.com",
                        WorkspaceType = Workspace.PrivateRooms,
                        StartDate = DateTime.SpecifyKind(
                            new DateTime(2025, 5, 27, 10, 0, 0),
                            DateTimeKind.Utc
                        ),
                        EndDate = DateTime.SpecifyKind(
                            new DateTime(2025, 5, 28, 23, 0, 0),
                            DateTimeKind.Utc
                        ),
                        CreatedAt = DateTime.SpecifyKind(
                            new DateTime(2025, 6, 1, 12, 0, 0),
                            DateTimeKind.Utc
                        ),
                        Status = Status.Active,
                        BookingsListId = 1,
                    },
                    new Booking
                    {
                        Id = 5,
                        Name = "Ethan",
                        Email = "ethan@example.com",
                        WorkspaceType = Workspace.MeetingRooms,
                        StartDate = DateTime.SpecifyKind(
                            new DateTime(2025, 5, 27, 10, 0, 0),
                            DateTimeKind.Utc
                        ),
                        EndDate = DateTime.SpecifyKind(
                            new DateTime(2025, 5, 27, 14, 0, 0),
                            DateTimeKind.Utc
                        ),
                        CreatedAt = DateTime.SpecifyKind(
                            new DateTime(2025, 6, 1, 12, 0, 0),
                            DateTimeKind.Utc
                        ),
                        Status = Status.Active,
                        BookingsListId = 1,
                    },
                    new Booking
                    {
                        Id = 6,
                        Name = "Fiona",
                        Email = "fiona@example.com",
                        WorkspaceType = Workspace.MeetingRooms,
                        StartDate = DateTime.SpecifyKind(
                            new DateTime(2025, 5, 27, 17, 0, 0),
                            DateTimeKind.Utc
                        ),
                        EndDate = DateTime.SpecifyKind(
                            new DateTime(2025, 5, 27, 20, 0, 0),
                            DateTimeKind.Utc
                        ),
                        CreatedAt = DateTime.SpecifyKind(
                            new DateTime(2025, 6, 1, 12, 0, 0),
                            DateTimeKind.Utc
                        ),
                        Status = Status.Active,
                        BookingsListId = 2,
                    },
                    new Booking
                    {
                        Id = 7,
                        Name = "George",
                        Email = "george@example.com",
                        WorkspaceType = Workspace.MeetingRooms,
                        StartDate = DateTime.SpecifyKind(
                            new DateTime(2025, 5, 28, 10, 0, 0),
                            DateTimeKind.Utc
                        ),
                        EndDate = DateTime.SpecifyKind(
                            new DateTime(2025, 5, 28, 18, 0, 0),
                            DateTimeKind.Utc
                        ),
                        CreatedAt = DateTime.SpecifyKind(
                            new DateTime(2025, 6, 1, 12, 0, 0),
                            DateTimeKind.Utc
                        ),
                        Status = Status.Active,
                        BookingsListId = 2,
                    },
                    new Booking
                    {
                        Id = 8,
                        Name = "Hannah",
                        Email = "hannah@example.com",
                        WorkspaceType = Workspace.OpenSpace,
                        StartDate = DateTime.SpecifyKind(
                            new DateTime(2025, 5, 30, 10, 0, 0),
                            DateTimeKind.Utc
                        ),
                        EndDate = DateTime.SpecifyKind(
                            new DateTime(2025, 6, 1, 23, 0, 0),
                            DateTimeKind.Utc
                        ),
                        CreatedAt = DateTime.SpecifyKind(
                            new DateTime(2025, 6, 1, 12, 0, 0),
                            DateTimeKind.Utc
                        ),
                        Status = Status.Active,
                        BookingsListId = 2,
                    },
                    new Booking
                    {
                        Id = 9,
                        Name = "Ian",
                        Email = "ian@example.com",
                        WorkspaceType = Workspace.PrivateRooms,
                        StartDate = DateTime.SpecifyKind(
                            new DateTime(2025, 5, 30, 10, 0, 0),
                            DateTimeKind.Utc
                        ),
                        EndDate = DateTime.SpecifyKind(
                            new DateTime(2025, 5, 30, 23, 0, 0),
                            DateTimeKind.Utc
                        ),
                        CreatedAt = DateTime.SpecifyKind(
                            new DateTime(2025, 6, 1, 12, 0, 0),
                            DateTimeKind.Utc
                        ),
                        Status = Status.Active,
                        BookingsListId = 2,
                    },
                    new Booking
                    {
                        Id = 10,
                        Name = "Julia",
                        Email = "julia@example.com",
                        WorkspaceType = Workspace.PrivateRooms,
                        StartDate = DateTime.SpecifyKind(
                            new DateTime(2025, 6, 2, 10, 0, 0),
                            DateTimeKind.Utc
                        ),
                        EndDate = DateTime.SpecifyKind(
                            new DateTime(2025, 6, 5, 23, 0, 0),
                            DateTimeKind.Utc
                        ),
                        CreatedAt = DateTime.SpecifyKind(
                            new DateTime(2025, 6, 1, 12, 0, 0),
                            DateTimeKind.Utc
                        ),
                        Status = Status.Active,
                        BookingsListId = 2,
                    }
                );
        }
    }
}
