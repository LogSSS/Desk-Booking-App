namespace Core.DTOs
{
    public class CapacityDTO
    {
        public CapacityDTO()
        {
            RoomAvailabilities = [];
        }

        public int Id { get; set; }
        public IList<RoomAvailabilityDTO> RoomAvailabilities { get; set; }
    }
}
