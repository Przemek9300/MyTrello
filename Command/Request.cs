using System;
using MediatR;

namespace trelloApi.Command
{
    public class LoginCommand:IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
        public class RegisterCommand:IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}