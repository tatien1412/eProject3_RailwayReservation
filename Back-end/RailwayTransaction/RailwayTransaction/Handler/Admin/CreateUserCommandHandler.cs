using MediatR;
using RailwayTransaction.Application.Commands.Admin;
using RailwayTransaction.Domain.Entities.Dtos;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.Admin
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDetail>
    {
        private readonly IRepository<AppUser, string> _repository;
        public CreateUserCommandHandler(IRepository<AppUser, string> repository)
        {
            _repository = repository;
        }
        public async Task<UserDetail> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var appUser = new AppUser
            {
                FullName = command.FullName,
                UserName = command.UserName,
                Email = command.Email,
                PasswordHash = command.Password,  
                PhoneNumber = command.PhoneNumber,
            };

            var addedUser = await _repository.AddAsync(appUser);

            var userDetail = new UserDetail
            {
                Id = addedUser.Id,
                FullName = addedUser.FullName,
                UserName = addedUser.UserName,
                Email = addedUser.Email,
                Password = addedUser.PasswordHash,
                PhoneNumber = addedUser.PhoneNumber,
                Role = command.Role  
            };

            return userDetail;
        }
    }
}
