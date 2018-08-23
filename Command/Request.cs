using System;
using MediatR;
using trelloApi.Domains;
using trelloApi.DTO;

namespace trelloApi.Command
{
    public class LoginCommand:IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
        public class RegisterCommand:IRequest<UserDTO>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
        public class CreateBoardCommand:IRequest<BoardDTO>
    {
        public int UserId { get; set; }
        public int BoardId { get; set; }
        public string Title { get; set; }
    }
}