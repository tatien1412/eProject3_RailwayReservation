namespace RailwayTransaction.Domain.Entities.Dtos.Response
{
    public class TrainResponse
    {
        public int TrainID { get; set; }
        public string TrainName { get; set; }
        public string Route { get; set; }
        public int NumberOfCompartments { get; set; }
    }
}
s