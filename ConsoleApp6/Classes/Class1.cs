using System;

namespace ConsoleApp6.Classes
{
    class Individual : Person, IComparable<Individual>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public Individual(long ID, string TIN, DateTime DateCreated, long CreatorID, DateTime? DateEdited, long? EditorID, string FirstName, string LastName, string MiddleName)
        {
            this.ID = ID;
            this.TIN = TIN;
            this.DateCreated = DateCreated;
            this.CreatorID = CreatorID;
            this.DateEdited = DateEdited;
            this.EditorID = EditorID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.MiddleName = MiddleName;
        }
        public int CompareTo(Individual indiv)
        {
            if (indiv == null)
                return 1;
            return FirstName.CompareTo(indiv.FirstName);
        }
    }
}
