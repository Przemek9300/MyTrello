using System;

namespace trelloApi.Domains
{
    public class Note
    {
        public int NoteId { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public bool Hide { get; set; }
        public Table Table { get; set; }
    }
}