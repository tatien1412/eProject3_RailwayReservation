namespace RailwayTransaction.Domain.Entities.Dtos.Response.StaffReponse
{
    public class BookingTrainReponse
    {
        public int TrainID { get; set; }
        public string TrainName { get; set; }
        public string TrainStatus { get; set; }

        public int NumberOfCompartments { get; set; }
        public int TrainRouteID { get; set; }
        public string DateofTravel { get; set; }
    }
}
