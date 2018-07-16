using System;
using System.Collections.Generic;

namespace trelloApi.Domains
{
    public class Board
    {
        public Guid BoardId { get; set; }
        public string Title { get; set; }
        public Group Group { get; set; }
        public List<Note> Notes { get; set; }
        
    }
}