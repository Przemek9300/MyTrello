using System;

namespace trelloApi.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }

        public string Email { get; set; }
        public string Avatar { get; set; }
    }
}