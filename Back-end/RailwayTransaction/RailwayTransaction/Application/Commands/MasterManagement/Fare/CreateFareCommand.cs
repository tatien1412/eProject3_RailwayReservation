using MediatR;

namespace RailwayTransaction.Application.Commands.MasterManagement.Fare
{
    public class CreateFareCommand : IRequest<int>
    {
        public int ReservationID { get; set; }
        public int Distance { get; set; }
        public string CompartmentType { get; set; }
        public string TrainType { get; set; }
        public decimal Amount { get; set; }
    }
}
