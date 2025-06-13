using Shared.Enums;

namespace API.Entities
{
    public class UpsertBookingRequest
    {
        public UpsertBookingRequest()
        {
            Name = string.Empty;
            Email = string.Empty;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public WorkspaceType WorkspaceType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int RoomSize { get; set; }

        public int WorkspaceId { get; set; }

        public Status Status { get; set; }

        public int OwnerId { get; set; }
    }
}
