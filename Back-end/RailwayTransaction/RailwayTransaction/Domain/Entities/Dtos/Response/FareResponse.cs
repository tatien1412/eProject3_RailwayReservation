namespace RailwayTransaction.Domain.Entities.Dtos.Response
{
    public class FareResponse
    {
        public int FareID { get; set; }
        public int Distance { get; set; }
        public string CompartmentType { get; set; }
        public string TrainType { get; set; }
        public decimal Amount { get; set; }
    }
}
