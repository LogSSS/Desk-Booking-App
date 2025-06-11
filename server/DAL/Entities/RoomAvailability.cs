using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("RoomAvailabilities")]
    public class RoomAvailability
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int CapacityId { get; set; }

        [ForeignKey("CapacityId")]
        public Capacity? Capacity { get; set; }

        public int MaxPeople { get; set; }

        public int AvailableRooms { get; set; }
    }
}
