using System.Collections.Generic;

namespace trelloApi.Domains
{
    public class Table
    {
        public int TableId { get; set; }
        public string Title { get; set; }
        public List<Note> Notes { get; set; }
    }
}