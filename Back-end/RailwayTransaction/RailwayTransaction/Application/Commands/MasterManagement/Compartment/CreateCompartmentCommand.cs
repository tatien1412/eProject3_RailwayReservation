using MediatR;

namespace RailwayTransaction.Application.Commands.MasterManagement.Compartment
{
    public class CreateCompartmentCommand : IRequest<int>
    {
        public int TrainID { get; set; }
        public string CompartmentType { get; set; }
        public string SeatType {  get; set; }
        public int NumberOfSeats { get; set; }
    }
}
