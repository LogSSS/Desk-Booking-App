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

        public int WorkspaceType { get; set; }

        public int Status { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int BookingsListId { get; set; }
    }
}
