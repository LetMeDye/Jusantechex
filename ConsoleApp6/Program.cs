using System;
using ConsoleApp6.Classes;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Newtonsoft.Json;

namespace ConsoleApp6
{
    class Program
    {
        //default build path, readonly so it wont'be skewed, could use const instead of static+readonly but who cares
        static readonly string directory = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
        static void Main()
        {
            //list of Legals with new initializing method thanks dotNet 5
            List<Legal> Companies = new List<Legal>();
            //list of people
            List<Individual> People = new List<Individual>();
            Legal government = new Legal(1, "001", DateTime.ParseExact("16/12/1991", "dd/MM/yyyy", CultureInfo.InvariantCulture), 400706,DateTime.MinValue, 0, "Nur Otan");
            string readData = File.ReadAllText(directory + @"\Data\LegalsList.json"); //reading the json file into a string
            Companies = JsonConvert.DeserializeObject<List<Legal>>(readData); //transforming the read data into a list of legals
            Companies.Add(government);
            #region Manual data for checking the functionality of legals
            //Companies = new List<Legal>() {
            //    government,
            //new Legal(2, "002", DateTime.ParseExact("28/01/1993","dd/MM/yyyy", CultureInfo.InvariantCulture), government.ID, DateTime.ParseExact("30/08/1995", "dd/MM/yyyy", CultureInfo.InvariantCulture), government.ID, "Constituion of Nur Otan"), //lmao
            //new Legal(3, "003", DateTime.ParseExact("17/01/1992", "dd/MM/yyyy", CultureInfo.InvariantCulture), government.ID, DateTime.ParseExact("06/09/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture), government.ID, "Jusan Bank"), //lmao x2, second date is ATF acquisition
            //new Legal(4, "004", DateTime.ParseExact("01/05/2012", "dd/MM/yyyy", CultureInfo.InvariantCulture), government.ID, DateTime.ParseExact("02/12/2020", "dd/MM/yyyy", CultureInfo.InvariantCulture), government.ID, "Burger King"), //lmao x3
            //new Legal(5, "005", DateTime.ParseExact("01/01/2012", "dd/MM/yyyy", CultureInfo.InvariantCulture), government.ID, DateTime.ParseExact("01/01/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture), government.ID, "Altyn orda"),};
            #endregion
            Individual mom = new Individual(23, "228", DateTime.MinValue, 0, null, null, "Bakyt", "Kadyrbekova", "Matenovna");
            readData = File.ReadAllText(directory + @"\Data\IndividualsList.json"); //reading the json file into a string
            People = JsonConvert.DeserializeObject<List<Individual>>(readData); //transforming the read data into a list of Indivduals
            People.Add(mom);
            #region Manual data for checking the functionality of Individuals
            //People = new List<Individual>() {
            //    mom,
            //    new Individual(54, "42069", DateTime.ParseExact("25/12/1998", "dd/MM/yyyy", CultureInfo.InvariantCulture), mom.ID, DateTime.ParseExact("25/12/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture), government.ID, "Asset", "Aden", "Kairatuly"),
            //    new Individual(53, "18021", DateTime.ParseExact("18/02/1992", "dd/MM/yyyy", CultureInfo.InvariantCulture), mom.ID, DateTime.ParseExact("18/02/2022", "dd/MM/yyyy", CultureInfo.InvariantCulture), government.ID, "Assel", "Aden", "Kairatovna"),
            //    new Individual(50, "07092", DateTime.ParseExact("07/09/2002", "dd/MM/yyyy", CultureInfo.InvariantCulture), mom.ID, DateTime.ParseExact("07/09/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture), government.ID, "Richard", "Son", null),
            //    new Individual(57, "27092", DateTime.ParseExact("27/09/2004", "dd/MM/yyyy", CultureInfo.InvariantCulture), mom.ID, DateTime.ParseExact("27/09/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture), government.ID, "Kseniya", "Leiko", "Alekseevna"),
            //    new Individual(59, "14051", DateTime.ParseExact("14/05/1977", "dd/MM/yyyy", CultureInfo.InvariantCulture), mom.ID, DateTime.ParseExact("14/05/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture), government.ID, "Natalia", "Leiko", "Viktorovna"),
            //    new Individual(70, "01061", DateTime.ParseExact("01/06/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture), mom.ID, DateTime.ParseExact("01/06/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture), government.ID, "Batyy", "Otan", "Erzhanuly"),
            //};
            #endregion
            #region Adding people to different companies\legals
            Companies[0].AddIndividuals(People);
            People.RemoveAll(p => p.FirstName == "Richard"); //Not kazakh, so our constitution doesnt matter
            Companies[1].AddIndividuals(People);
            Companies[3].AddIndividuals(People); //Everyone loves BK(no one does)
            People.RemoveAll(p => DateTime.Now.Year - p.DateCreated.Year < 21); //remove all the adolescents
            Companies[2].AddIndividuals(People); //you cant have a credit if you're <21
            Companies[Companies.Count-1].AddIndividuals(People); //do not go to altyn orda if you're < 21, you'll be kidnapped and human traffick'd
            #endregion
            //Sorting companies by their customer size!
            Companies.Sort();
            //Showing the companies from most to lowest people size
            foreach (var legals in Companies)
            {
                Console.WriteLine(legals.CompanyName + " has " + legals.individuals.Count + " people!");
            }
            //Sorting people by their first name
            People.Sort();
            //showing People sorted by their first name RIP, my sister is higher than me :<
            foreach (var peoples in People)
            {
                Console.WriteLine(peoples.FirstName + " " + peoples.LastName + (peoples.MiddleName == null ? "" : " " + peoples.MiddleName));
            }

            //Serializing and writing JSON to JSON file
            using (StreamWriter sw = File.CreateText(directory + @"\Data\IndividualsList.json"))
            {
                string json = JsonConvert.SerializeObject(People, Formatting.Indented);
                sw.Write(json);
            }
            //same for companies/legals
            using (StreamWriter sw = File.CreateText(directory + @"\Data\LegalsList.json"))
            {
                string json = JsonConvert.SerializeObject(Companies, Formatting.Indented);
                sw.Write(json);
            }
            Console.Read();
        }
    }
}
