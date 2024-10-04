using MediatR;

namespace RailwayTransaction.Application.Queries.Staff.Booking
{
    public class UpdateReverseSeatQueueStatusQuery: IRequest
    {
        public int TrainID { get; set; }
        public string CompartmentType { get; set; }
        public int TotalConFirmTicket { get; set; }
        public UpdateReverseSeatQueueStatusQuery(int trainID, string compartmentType, int totalConFirmTicket)
        {
            TrainID = trainID;
            CompartmentType = compartmentType;
            TotalConFirmTicket = totalConFirmTicket;
        }
    }
}
