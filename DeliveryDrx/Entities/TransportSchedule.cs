using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DeliveryDrxAPI.Entities
{
    public class TransportSchedule
    {
        [Key]
        public int Id { get; set; }
        public DateTime TimeReceiving { get; set; }

        public int GateId { get; set; }
        [ForeignKey("GateId")]
        public Gate Gate { get; set; }

        public int TransportId { get; set; }
        public Transport Transport { get; set; }
    }
}
