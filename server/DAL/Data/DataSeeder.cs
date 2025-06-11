using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Shared.Enums;

namespace DAL.Data
{
    public class DataSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Booking>()
                .HasData(
                    new Booking
                    {
                        Id = 1,
                        Name = "Alice",
                        Email = "alice@example.com",
                        OwnerId = 1,
                        WorkspaceId = -1,
                        StartDate = DateTime.SpecifyKind(
                            new DateTime(2025, 6, 25, 10, 0, 0),
                            DateTimeKind.Utc
                        ),
                        EndDate = DateTime.SpecifyKind(
                            new DateTime(2025, 6, 26, 23, 0, 0),
                            DateTimeKind.Utc
                        ),
                        CreatedAt = DateTime.SpecifyKind(
                            new DateTime(2025, 6, 1, 12, 0, 0),
                            DateTimeKind.Utc
                        ),
                        Status = Status.Active,
                    },
                    new Booking
                    {
                        Id = 2,
                        Name = "Bob",
                        Email = "bob@example.com",
                        OwnerId = 2,
                        WorkspaceId = -2,
                        StartDate = DateTime.SpecifyKind(
                            new DateTime(2025, 6, 27, 10, 0, 0),
                            DateTimeKind.Utc
                        ),
                        EndDate = DateTime.SpecifyKind(
                            new DateTime(2025, 6, 28, 23, 0, 0),
                            DateTimeKind.Utc
                        ),
                        CreatedAt = DateTime.SpecifyKind(
                            new DateTime(2025, 6, 1, 12, 0, 0),
                            DateTimeKind.Utc
                        ),
                        Status = Status.Active,
                    }
                );

            modelBuilder
                .Entity<Workspace>()
                .HasData(
                    new Workspace
                    {
                        Id = -1,
                        Name = "Open Space",
                        Type = WorkspaceType.OpenSpace,
                        Description = """
                            A vibrant shared area perfect for freelancers or small teams 
                            who enjoy a collaborative atmosphere. Choose any
                            available desk and get to work with flexibility and ease.
                        """,
                    },
                    new Workspace
                    {
                        Id = -2,
                        Name = "Private Rooms",
                        Type = WorkspaceType.PrivateRooms,
                        Description = """
                            Ideal for focused work, video calls, or small 
                            team huddles.These fully enclosed rooms offer privacy and
                            come in a variety of sizes to fit your needs.
                        """,
                    },
                    new Workspace
                    {
                        Id = -3,
                        Name = "Meeting Rooms",
                        Type = WorkspaceType.MeetingRooms,
                        Description = """
                           Designed for productive meetings, workshops, 
                           or client presentations. Equipped with screens, whiteboards,
                           and comfortable seating to keep your sessions running smoothly.
                        """,
                    }
                );

            modelBuilder
                .Entity<Amenity>()
                .HasData(
                    new Amenity
                    {
                        Id = -1,
                        IconId = 1,
                        WorkspaceId = -1,
                    },
                    new Amenity
                    {
                        Id = -2,
                        IconId = 2,
                        WorkspaceId = -1,
                    },
                    new Amenity
                    {
                        Id = -3,
                        IconId = 3,
                        WorkspaceId = -1,
                    },
                    new Amenity
                    {
                        Id = -4,
                        IconId = 4,
                        WorkspaceId = -1,
                    },
                    new Amenity
                    {
                        Id = -5,
                        IconId = 3,
                        WorkspaceId = -2,
                    },
                    new Amenity
                    {
                        Id = -6,
                        IconId = 1,
                        WorkspaceId = -2,
                    },
                    new Amenity
                    {
                        Id = -7,
                        IconId = 5,
                        WorkspaceId = -2,
                    },
                    new Amenity
                    {
                        Id = -8,
                        IconId = 3,
                        WorkspaceId = -3,
                    },
                    new Amenity
                    {
                        Id = -9,
                        IconId = 1,
                        WorkspaceId = -3,
                    },
                    new Amenity
                    {
                        Id = -10,
                        IconId = 5,
                        WorkspaceId = -3,
                    },
                    new Amenity
                    {
                        Id = -11,
                        IconId = 6,
                        WorkspaceId = -3,
                    }
                );

            modelBuilder
                .Entity<Capacity>()
                .HasData(
                    new Capacity { Id = -1, WorkspaceId = -1 },
                    new Capacity { Id = -2, WorkspaceId = -2 },
                    new Capacity { Id = -3, WorkspaceId = -3 }
                );

            modelBuilder
                .Entity<RoomAvailability>()
                .HasData(
                    new RoomAvailability
                    {
                        Id = -1,
                        CapacityId = -1,
                        MaxPeople = 0,
                        AvailableRooms = 24,
                    },
                    new RoomAvailability
                    {
                        Id = -2,
                        CapacityId = -2,
                        MaxPeople = 1,
                        AvailableRooms = 7,
                    },
                    new RoomAvailability
                    {
                        Id = -3,
                        CapacityId = -2,
                        MaxPeople = 2,
                        AvailableRooms = 4,
                    },
                    new RoomAvailability
                    {
                        Id = -4,
                        CapacityId = -2,
                        MaxPeople = 5,
                        AvailableRooms = 3,
                    },
                    new RoomAvailability
                    {
                        Id = -5,
                        CapacityId = -2,
                        MaxPeople = 10,
                        AvailableRooms = 1,
                    }
                );
        }
    }
}
