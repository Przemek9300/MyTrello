using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace trelloApi.Domains
{
    public class Group
    {
        [Key]
        public Guid GroupId { get; set; }
        public string Name  { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public virtual ICollection<GroupUser> GroupUser { get; set; }
        public User Owner { get; set; }
    }
}