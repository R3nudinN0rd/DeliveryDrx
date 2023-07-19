namespace DeliveryDrxAPI.Mapper.Models
{
    public class TransportDTO
    {
        public int Id { get; set; }
        public string StatusTransport { get; set; }
        public DateTime ExpeditionDate { get; set; }
        public DateTime ReceivingDate { get; set; }

        public int? LocationId { get; set; }

        public int? DriverId { get; set; }
    }
}
