using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("Capacities")]
    public class Capacity
    {
        public Capacity()
        {
            RoomAvailabilities = [];
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int WorkspaceId { get; set; }

        [ForeignKey("WorkspaceId")]
        public Workspace? Workspace { get; set; }

        public IList<RoomAvailability> RoomAvailabilities { get; set; }
    }
}
