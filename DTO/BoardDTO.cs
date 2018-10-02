using System;
using System.Collections.Generic;
using trelloApi.Domains;

namespace trelloApi.DTO
{
    public class BoardDTO
    {
        public int BoardId { get; set; }
        public string Title { get; set; }
        public List<Table> Table { get; set; }    }
}