using MediatR;

namespace RailwayTransaction.Application.Commands.Staff
{
    public class UpdateSeatStatusCommand : IRequest
    {
        public int TrainID { get; set; }
        public string CompartmentType {  get; set; }
        public int TotalConFirmTicket {  get; set; }
    }
}
