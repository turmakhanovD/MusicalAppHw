using System;

namespace MusicalApp
{
    public class Group : Entity
    {
        public string Name { get; set; }
        public int MemberCount { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
