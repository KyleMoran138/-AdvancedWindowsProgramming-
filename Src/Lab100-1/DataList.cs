using System;
using System.Collections.Generic;
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

    }
}
