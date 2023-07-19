using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DeliveryDrxAPI.Entities
{
    public class Gate
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("LocationId")]
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
