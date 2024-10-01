namespace RailwayTransaction.Domain.Entities.Dtos.Response.StaffReponse
{
    public class AvailabelSeatReponse
    {
        public int TrainId { get; set; }
        public int TotalAvailableSeatType1 {  get; set; }
        public int TotalAvailableSeatType2 { get; set; }
        public int TotalAvailableSeatType3 { get; set; }
    }
}
