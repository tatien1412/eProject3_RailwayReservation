namespace RailwayTransaction.Domain.Entities.Dtos.Response
{
    public class TrainResponse
    {
        public string TrainName { get; set; }
        public string TrainRouteDetails { get; set; }
        public int TrainRouteID { get; set; }
        public int NumberOfCompartments { get; set; }
    }
}