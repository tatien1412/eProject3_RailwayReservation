using MediatR;
using RailwayTransaction.Application.Commands.Admin;
using RailwayTransaction.Domain.Entities.Dtos;
using RailwayTransaction.Domain.Interface;
using Microsoft.AspNetCore.Identity;

namespace RailwayTransaction.Handler.Admin
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDetail>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IRepository<AppUser, string> _repository;
        private readonly IPasswordHasher<AppUser> _passwordHasher;

        public CreateUserCommandHandler(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IRepository<AppUser, string> repository, IPasswordHasher<AppUser> passwordHasher)
        {
            _userManager = userManager; 
            _roleManager = roleManager;
            _repository = repository;
            _passwordHasher = passwordHasher;
        }

        public async Task<UserDetail> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            // Kiểm tra xem user đã tồn tại hay chưa
            var existingUser = await _userManager.FindByNameAsync(command.UserName);
            if (existingUser != null)
            {
                throw new Exception($"Username '{command.UserName}' is already taken.");
            }

            var appUser = new AppUser
            {
                FullName = command.FullName,
                UserName = command.UserName,
                Email = command.Email,
                PhoneNumber = command.PhoneNumber,
            };

            // Sử dụng password hasher để mã hóa mật khẩu
            appUser.PasswordHash = _passwordHasher.HashPassword(appUser, command.Password);

            // Thêm user vào cơ sở dữ liệu
            var result = await _userManager.CreateAsync(appUser);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"Error creating user: {errors}");
            }

            if (!await _roleManager.RoleExistsAsync(command.Role))
            {
                var roleCreationResult = await _roleManager.CreateAsync(new IdentityRole(command.Role));
                if (!roleCreationResult.Succeeded)
                {
                    var roleErrors = string.Join(", ", roleCreationResult.Errors.Select(e => e.Description));
                    throw new Exception($"Error creating role: {roleErrors}");
                }
            }

            // Gán vai trò cho user
            var roleResult = await _userManager.AddToRoleAsync(appUser, command.Role);
            if (!roleResult.Succeeded)
            {
                throw new Exception("Error assigning role to user");
            }

            var userDetail = new UserDetail
            {
                Id = appUser.Id,
                FullName = appUser.FullName,
                UserName = appUser.UserName,
                Email = appUser.Email,
                Password = appUser.PasswordHash,
                PhoneNumber = appUser.PhoneNumber,
                Role = command.Role
            };

            return userDetail;
        }

    }
}
