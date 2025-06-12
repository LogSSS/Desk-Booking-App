namespace Core.DTOs
{
    public class BookingDTO
    {
        public BookingDTO()
        {
            Name = string.Empty;
            Email = string.Empty;
        }

        public int Id { get; set; }

        public int OwnerId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public WorkspaceDTO? Workspace { get; set; }

        public int Status { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int WorkspaceId { get; set; }

        public int RoomSize { get; set; }
    }
}
