using MediatR;
using RailwayTransaction.Application.Commands.Admin;
using RailwayTransaction.Domain.Entities.Dtos;
using RailwayTransaction.Domain.Interface;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RailwayTransaction.Handler.Admin
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IRepository<AppUser, string> _repository;
        public UpdateUserCommandHandler(IRepository<AppUser, string> repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var userExist = await _repository.GetByIdAsync(command.Id);
            if(userExist == null)
            {
                throw new Exception("User not found");
            }

            userExist.FullName = command.FullName;
            userExist.UserName = command.UserName;
            userExist.Email = command.Email;
            userExist.PasswordHash = command.Password;
            userExist.PhoneNumber = command.PhoneNumber;
            await _repository.UpdateAsync(userExist);

            return Unit.Value;
        }
    }
}
