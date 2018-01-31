using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab100_1 {
    class Person {
        public String FirstName;
        public String LastName;
        public String Address;
        public String City;
        public String State;
        public int Zip;

        public Person(String first, String last, String addr, String city, String state, int zip) {
            this.FirstName = first;
            this.LastName = last;
            this.Address = addr;
            this.City = city;
            this.State = state;
            this.Zip = zip;
        }

        public Person() : this(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 0) { }

        public bool Equals(Person other) {
            if (this == null) return false;
            if (this == other) return true;
            if(other == null || this.GetType() != other.GetType())
                return false;
            if (this.FirstName == null && other.FirstName == null) {
                return false;
            } else if (!FirstName.Equals(other.FirstName)) {
                return false;
            }

            if (this.LastName == null && other.LastName == null) {
                return false;
            } else if (!LastName.Equals(other.LastName)) {
                return false;
            }

            return true;
        }

        public int CompareTo(Person other) {
            if (this.LastName.Equals(other.LastName)) {
                return this.FirstName.CompareTo(other.FirstName);
            }
            return this.LastName.CompareTo(other.LastName);
        }

        public override string ToString() =>
            string.Format("{0,12} {1,-12} {2,30} {3,-24} {4,-6} {5:d5}", this.FirstName, this.LastName, this.Address, this.City, this.State, this.Zip);

    }
}
