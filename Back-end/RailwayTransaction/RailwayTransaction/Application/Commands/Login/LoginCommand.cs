using MediatR;
using System.ComponentModel.DataAnnotations;

namespace RailwayTransaction.Application.Commands.Login
{
    public class LoginCommand : IRequest<string>
    {
        [Required]
        public string UserName { get; set; } 
        [Required]
        public string Password { get; set; }
    }
}
