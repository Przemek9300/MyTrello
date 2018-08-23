using System;
using System.Collections.Generic;

namespace trelloApi.Domains
{
    public class Board
    {
        public int BoardId { get; set; }
        public string Title { get; set; }
        public User User { get; set; }
        public List<Table> Table { get; set; }
        
    }
}