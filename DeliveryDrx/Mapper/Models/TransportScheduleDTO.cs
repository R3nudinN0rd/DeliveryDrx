namespace DeliveryDrxAPI.Mapper.Models
{
    public class TransportScheduleDTO
    {
        public int Id { get; set; }
        public DateTime TimeReceiving { get; set; }

        public int GateId { get; set; }

        public int TransportId { get; set; }
    }
}
