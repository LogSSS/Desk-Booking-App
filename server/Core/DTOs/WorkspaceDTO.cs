using Shared.Enums;

namespace Core.DTOs
{
    public class BaseWorkspaceDTO
    {
        public BaseWorkspaceDTO()
        {
            Name = string.Empty;
            Images = [];
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public WorkspaceType Type { get; set; }

        public IList<MyImageDTO> Images { get; set; }
    }

    public class WorkspaceDTO : BaseWorkspaceDTO
    {
        public WorkspaceDTO()
        {
            Amenities = [];
            CapacityOptions = [];
            Description = string.Empty;
        }

        public string Description { get; set; }

        public IList<AmenityDTO> Amenities { get; set; }

        public IList<CapacityDTO> CapacityOptions { get; set; }

        public BookingDTO? Booked { get; set; }
    }
}
