using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shared.Enums;

namespace DAL.Entities
{
    [Table("Bookings")]
    public class Booking
    {
        public Booking()
        {
            Name = string.Empty;
            Email = string.Empty;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int OwnerId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public Status Status { get; set; }

        public int RoomSize { get; set; }

        public int WorkspaceId { get; set; }

        [ForeignKey("WorkspaceId")]
        public Workspace? Workspace { get; set; }
    }
}
