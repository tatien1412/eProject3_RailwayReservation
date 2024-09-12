using MediatR;
using RailwayTransaction.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailwayTransaction.Application.Commands.MasterManagement.Reservation
{
    public class UpdateReservationCommand : IRequest
    {
        public int ReservationID { get; set; }
        public int TripID { get; set; }
        public int PnrNo { get; set; }
        public DateTime DateOfJourney { get; set; }
        public decimal TotalFare { get; set; }  // Tổng tiền vé

    }
}
