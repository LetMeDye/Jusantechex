using System;
using System.Collections.Generic;

namespace ConsoleApp6.Classes
{
    class Legal : Person, IComparable<Legal>
    {
        public string CompanyName { get; set; }
        public readonly List<Individual> individuals = new List<Individual>();

        public Legal(long ID, string TIN, DateTime DateCreated, long CreatorID, DateTime DateEdited, long EditorID, string CompanyName)
        {
            this.ID = ID;
            this.TIN = TIN;
            this.DateCreated = DateCreated;
            this.CreatorID = CreatorID;
            this.DateEdited = DateEdited;
            this.EditorID = EditorID;
            this.CompanyName = CompanyName;
        }

        public void AddIndividuals(List<Individual> listOfIndividuals)
        {
            individuals.AddRange(listOfIndividuals);
        }
        public int CompareTo(Legal legal)
        {
            return legal.individuals.Count.CompareTo(individuals.Count);
        }
    }
}
