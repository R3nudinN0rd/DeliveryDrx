using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryDrxAPI.Entities
{
    public class LocationManager
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public int LocationId { get; set; }
        [ForeignKey("LocationId")]
        public  Location Location { get; set; }
    }
}
