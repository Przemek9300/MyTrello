using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace trelloApi.Domains
{
    public class User{
        public User()
        {
            Board = new List<Board>();
        }
        [Key]

        public int UserId { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public string HashPassword { get; set; }
        public string Salt { get; set; }

        public virtual ICollection<Board> Board { get; set; }
    }
}