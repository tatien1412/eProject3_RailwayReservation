using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using RailwayTransaction.Application.Commands.Login;
using RailwayTransaction.Domain.Entities.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RailwayTransaction.Handler.Login
{
    public class LoginHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _configuration;

        public LoginHandler(IConfiguration configuration, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _signInManager = signInManager;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            // Kiểm tra Username
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }

            // Kiểm tra Password
            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!result.Succeeded)
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }

            // Lấy danh sách vai trò của người dùng
            var roles = await _userManager.GetRolesAsync(user);

            // Tạo claims từ các vai trò
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            // Tạo Token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTSetting:securityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWTSetting:ValidIssuer"],
                audience: _configuration["JWTSetting:ValidAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(double.Parse(_configuration["JWTSetting:expireInMinutes"])),
                signingCredentials: creds
            );

            // Trả về token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
