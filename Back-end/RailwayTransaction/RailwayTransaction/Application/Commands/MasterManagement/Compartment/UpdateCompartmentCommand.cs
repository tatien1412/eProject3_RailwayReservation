using MediatR;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RailwayTransaction.Application.Commands.MasterManagement.Compartment
{
    public class UpdateCompartmentCommand : IRequest
    {
        public int CompartmentID { get; set; }
        public int TrainID { get; set; }
        public string CompartmentType { get; set; } 
        public string SeatType { get; set; }
        public int NumberOfSeats { get; set; }

    }
}
