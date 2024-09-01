using MediatR;
using RailwayTransaction.Domain.Entities.Dtos;

namespace RailwayTransaction.Application.Commands.Admin
{
    public class CreateUserCommand : IRequest<UserDetail>
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }

        public CreateUserCommand(string fullname, string email, string password, string phoneNumber, string role)
        {
            FullName = fullname;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            Role = role;
        }
    }
}
