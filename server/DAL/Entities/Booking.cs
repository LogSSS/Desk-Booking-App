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

        public string Name { get; set; }

        public string Email { get; set; }

        public Workspace WorkspaceType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public Status Status { get; set; }

        public int BookingsListId { get; set; }

        [ForeignKey("BookingsListId")]
        public BookingsList BookingsList { get; set; }
    }
}
