using System;

namespace MusicalApp
{
    public class Song : Entity
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public long Duration { get; set; }
        public int Rating { get; set; }
        public Guid GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}
