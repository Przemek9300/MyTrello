using System;

namespace trelloApi.Domains
{
    public class Note
    {
        public Guid NoteId { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public bool Hide { get; set; }
        public Board Board { get; set; }
    }
}