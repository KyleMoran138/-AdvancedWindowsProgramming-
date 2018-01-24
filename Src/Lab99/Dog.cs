using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab99 {
    class Dog : Pet{
        public string DogsBreed { get; set; }

        public Dog(PET_TYPE t, PET_COLOR c, string n, string breed) : base(t, c, n) { DogsBreed = breed; }
        public Dog(PET_TYPE t, PET_COLOR c, string n) : this(t, c, n, "Mutt") { }
        public override string WhenHappy() => "My tail waggs.";
        public override string Sound() => "Bark";
        public override string ToString() => $"{base.ToString()} I say {Sound()}, and when I am happy {WhenHappy()}.";

        

    }
}
