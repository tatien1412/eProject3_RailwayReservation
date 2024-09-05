using MediatR;
using RailwayTransaction.Application.Commands.Admin;
using Microsoft.AspNetCore.Identity;
using RailwayTransaction.Domain.Entities.Dtos;

namespace RailwayTransaction.Handler.Admin
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IPasswordHasher<AppUser> _passwordHasher;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UpdateUserCommandHandler(UserManager<AppUser> userManager, IPasswordHasher<AppUser> passwordHasher, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _passwordHasher = passwordHasher;
            _roleManager = roleManager;
        }

        public async Task<Unit> Handle(UpdateUserCommand command, CancellationToken cancellationToken)  // Thêm id vào tham số
        {
            var userExist = await _userManager.FindByIdAsync(command.Id);
            if (userExist == null)
            {
                throw new Exception("User not found");
            }

            // Cập nhật thông tin người dùng
            userExist.FullName = command.FullName;
            userExist.UserName = command.UserName;
            userExist.Email = command.Email;
            userExist.PhoneNumber = command.PhoneNumber;

            // Cập nhật mật khẩu nếu có thay đổi
            if (!string.IsNullOrEmpty(command.Password))
            {
                userExist.PasswordHash = _passwordHasher.HashPassword(userExist, command.Password);
            }

            // Xử lý cập nhật vai trò
            var currentRoles = await _userManager.GetRolesAsync(userExist);
            if (currentRoles.Count > 0)
            {
                // Xóa vai trò hiện tại
                await _userManager.RemoveFromRolesAsync(userExist, currentRoles);
            }

            // Lưu các thay đổi
            var result = await _userManager.UpdateAsync(userExist);
            if (!result.Succeeded)
            {
                throw new Exception("Failed to update user");
            }

            return Unit.Value;  // Trả về kết quả thành công
        }
    }
}
