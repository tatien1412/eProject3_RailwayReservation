using MediatR;

namespace RailwayTransaction.Application.Queries.Staff.Booking
{
    public class UpdateSeatQueueStatusQuery : IRequest
    {
        public int TrainID { get; set; }
        public string CompartmentType { get; set; }
        public int TotalConFirmTicket { get; set; }
        public UpdateSeatQueueStatusQuery(int trainID, string compartmentType, int totalConFirmTicket)
        {
            TrainID = trainID;
            CompartmentType = compartmentType;
            TotalConFirmTicket = totalConFirmTicket;
        }
    }
}
