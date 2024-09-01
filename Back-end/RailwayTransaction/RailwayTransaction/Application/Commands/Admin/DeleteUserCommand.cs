using MediatR;

namespace RailwayTransaction.Application.Commands.Admin
{
    public class DeleteUserCommand : IRequest
    {
        public string? Id { get; set; }
    }
}
