using MediatR;

namespace RailwayTransaction.Application.Commands.MasterManagement.Seat
{
    public class CreateSeatCommand : IRequest<int>
    {
        public int CompartmentID { get; set; }
        public string SeatNumber { get; set; }
        public string SeatStatus { get; set; }
        public string SeatType { get; set; }
        public decimal Fare { get; set; }
        public int ReservationID { get; set; }
    }
}
