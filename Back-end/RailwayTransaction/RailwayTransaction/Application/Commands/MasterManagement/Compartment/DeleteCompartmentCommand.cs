using MediatR;

namespace RailwayTransaction.Application.Commands.MasterManagement.Compartment
{
    public class DeleteCompartmentCommand : IRequest
    {
        public int CompartmentID { get; set; }
    }
}
