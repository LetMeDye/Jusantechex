using System;

namespace ConsoleApp6.Classes
{
    class Person
    {
        public long ID { get; set; }
        public string TIN { get; set; } //Taxpayers' Identification Numbers
        public DateTime DateCreated { get; set; }
        public long CreatorID { get; set; }
        public DateTime? DateEdited { get; set; }
        public long? EditorID { get; set; }
    }
}
