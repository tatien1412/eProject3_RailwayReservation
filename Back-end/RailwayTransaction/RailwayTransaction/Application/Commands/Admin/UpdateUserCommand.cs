using MediatR;

namespace RailwayTransaction.Application.Commands.Admin
{
    public class UpdateUserCommand : IRequest
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }

        public UpdateUserCommand(string fullName, string username, string email, string password, string phoneNumber)
        {
            FullName = fullName;
            UserName = username;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
        }
    }
}
