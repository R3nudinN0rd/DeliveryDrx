using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DeliveryDrxAPI.Entities
{
    public class Transport
    {
        [Key]
        public int Id { get; set; }
        public string StatusTransport { get; set; }
        public DateTime ExpeditionDate { get; set; }
        public DateTime ReceivingDate { get; set; }

        public int? LocationId { get; set; }
        [ForeignKey("LocationId")]
        public  Location Location{ get; set; }

        public int? DriverId { get; set; }
        [ForeignKey("DriverId")]
        public  Driver Driver { get; set; }
    }
}
