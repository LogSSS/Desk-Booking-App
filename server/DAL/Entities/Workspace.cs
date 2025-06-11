using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shared.Enums;

namespace DAL.Entities
{
    [Table("Workspaces")]
    public class Workspace
    {
        public Workspace()
        {
            Name = string.Empty;
            Description = string.Empty;
            Amenities = [];
            CapacityOptions = [];
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public WorkspaceType Type { get; set; }

        public string Description { get; set; }

        public IList<Amenity> Amenities { get; set; }

        public IList<Capacity> CapacityOptions { get; set; }

        public Booking? Booked { get; set; }
    }
}
