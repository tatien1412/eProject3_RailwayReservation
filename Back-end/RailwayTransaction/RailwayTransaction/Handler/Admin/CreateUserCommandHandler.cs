using MediatR;
using RailwayTransaction.Application.Commands.Admin;
using RailwayTransaction.Domain.Entities.Dtos;
using RailwayTransaction.Domain.Interface;
using Microsoft.AspNetCore.Identity;  // Thêm thư viện này

namespace RailwayTransaction.Handler.Admin
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDetail>
    {
        private readonly IRepository<AppUser, string> _repository;
        private readonly IPasswordHasher<AppUser> _passwordHasher;  // Thêm IPasswordHasher

        public CreateUserCommandHandler(IRepository<AppUser, string> repository, IPasswordHasher<AppUser> passwordHasher)
        {
            _repository = repository;
            _passwordHasher = passwordHasher;  // Khởi tạo password hasher
        }

        public async Task<UserDetail> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var appUser = new AppUser
            {
                FullName = command.FullName,
                UserName = command.UserName,
                Email = command.Email,
                PhoneNumber = command.PhoneNumber,
            };

            // Sử dụng password hasher để mã hóa mật khẩu
            appUser.PasswordHash = _passwordHasher.HashPassword(appUser, command.Password);

            var addedUser = await _repository.AddAsync(appUser);

            var userDetail = new UserDetail
            {
                Id = addedUser.Id,
                FullName = addedUser.FullName,
                UserName = addedUser.UserName,
                Email = addedUser.Email,
                Password = addedUser.PasswordHash,  // Đây là mật khẩu đã mã hóa
                PhoneNumber = addedUser.PhoneNumber,
                Role = command.Role
            };

            return userDetail;
        }
    }
}
