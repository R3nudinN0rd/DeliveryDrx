using System.ComponentModel.DataAnnotations;

namespace DeliveryDrxAPI.Entities
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        public string Address { get; set; }
    }
}
