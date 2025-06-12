using Shared.Enums;

namespace Core.DTOs
{
    public class WorkspaceDTO
    {
        public WorkspaceDTO()
        {
            Name = string.Empty;
            Description = string.Empty;
            Amenities = [];
            CapacityOptions = [];
            Images = [];
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public WorkspaceType Type { get; set; }

        public string Description { get; set; }

        public IList<AmenityDTO> Amenities { get; set; }

        public IList<CapacityDTO> CapacityOptions { get; set; }

        public BookingDTO? Booked { get; set; }

        public IList<MyImage> Images { get; set; }
    }
}
