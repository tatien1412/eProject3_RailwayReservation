using MediatR;

namespace RailwayTransaction.Application.Commands.MasterManagement.Fare
{
    public class DeleteFareCommand : IRequest
    {
        public int FareID { get; set; }
    }
}
