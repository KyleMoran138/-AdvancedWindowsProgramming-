using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab100_1 {
    class DataList {
        private List<Person> personList;
        public string FileName; 
        public DataList(string fname) {
            FileName = fname;
            personList = new List<Person>();
        }
        public Person FindPerson(String lastName) {
            var person = from p in personList
                         where p.LastName == lastName
                         select p;
            return person.FirstOrDefault();
        }
        public Person GetPersonAt(int i) {
            return personList.ElementAt(i);
        }
        public Person FindPerson(Person otherPerson) {
            var per = from p in personList
                      where p.Equals(otherPerson)
                      select p;
            return personList.FirstOrDefault();
        }
        public string FindPersonsAddress(Person otherPerson) {
            string addr = null;
            var persons = from p in personList
                          where p.Equals(otherPerson)
                          select p;
            Person p1 = persons.FirstOrDefault();
            if(p1 != null) {
                addr = string.Format($"{p1.FirstName}'s address is: " + $"{p1.Address} {p1.City} {p1.State} {p1.Zip}");
            }
            return addr;
        }
        public List<Person> FindPeropleWithSameLastName(string lastname) {
            return (from p in personList
                   where p.LastName.Equals(lastname)
                   select p).ToList();
        }
        public void InsertPerson(String first, String last, String addr, String city, String state, int zip) {
            personList.Add(new Lab100_1.Person(first, last, addr, city, state, zip));
            return;
        }
        public void DisplayPeopleByCity(string c) {
            var byCity = from p in personList
                         where p.City == c
                         select p;
            byCity.ToList<Person>().ForEach(x => Console.WriteLine(x));
            return;
        }
        public void DisplayPeopleByCityAndState(string c, string s) {
            var byCity = from p in personList
                         where (p.City == c && p.State == s)
                         select p;
            byCity.ToList<Person>().ForEach(x => Console.WriteLine(x));
            return;
        }
        public bool DeletePerson(Person thisPerson) => personList.Remove(thisPerson);
        public void DisplayPeople() {
            int i = 0;
            personList.ForEach(x => Console.WriteLine($"{++i,6}) {x}"));
        }
        public int LoadData() {
            string line;
            string[] words;
            int NumOfRecords = 0;

            StreamReader reader = new StreamReader(FileName);
            try {
                do {
                    NumOfRecords++;
                    line = reader.ReadLine();
                    words = line.Split(new String[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    personList.Add(new Person(words[0], words[1], words[2], words[3], words[4], Convert.ToInt32(words[5])));
                } while (reader.Peek() != -1);
            }catch(Exception e) {
                Console.WriteLine("Error: "+ e.Message);
            } finally {
                reader.Close();
            }
            Console.WriteLine($"Loading records, number of records read: {NumOfRecords}");
            return NumOfRecords;
        }
        public string CompareTwoPersons(Person p1, Person p2) {
            int compare = p1.CompareTo(p2);
            string retValue = "";
            switch (compare) {
                case -1:
                    retValue = $"{p1.FirstName} {p1.LastName} is less than to {p2.FirstName} {p2.LastName}";
                    break;
                case 0:
                    retValue = $"{p1.FirstName} {p1.LastName} is equal to {p2.FirstName} {p2.LastName}";
                    break;
                case 1:
                    retValue = $"{p1.FirstName} {p1.LastName} is greater than to {p2.FirstName} {p2.LastName}";
                    break;
                    defualt:
                    Console.WriteLine("This cannot happen, fix your code...");
                    retValue = $"{p1.FirstName} {p1.LastName} ...default... {p2.FirstName} {p2.LastName}";
                    break;
            }
            return retValue;
        }

    }
}
