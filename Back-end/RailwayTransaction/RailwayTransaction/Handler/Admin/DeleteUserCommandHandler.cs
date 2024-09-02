using MediatR;
using RailwayTransaction.Application.Commands.Admin;
using RailwayTransaction.Domain.Entities.Dtos;
using RailwayTransaction.Domain.Interface;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RailwayTransaction.Handler.Admin
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IRepository<AppUser, string> _repository;
        public DeleteUserCommandHandler(IRepository<AppUser, string> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            var userExist = await _repository.GetByIdAsync(command.Id);
            if (userExist == null)
            {
                throw new Exception("User not found");
            }
            await _repository.DeleteAsync(userExist);
            return Unit.Value;
        }
    }
}
