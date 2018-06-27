using System;

namespace trelloApi.Domains
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public string HashPassword { get; set; }
        public string Salt { get; set; }
    }
}