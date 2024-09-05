using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json.Serialization;

namespace RailwayTransaction.Application.Commands.Admin
{
    public class UpdateUserCommand : IRequest
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }

        public UpdateUserCommand(string fullName, string username, string email, string password, string phoneNumber, string role)
        {
            FullName = fullName;
            UserName = username;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            Role = role;
        }
    }
}
