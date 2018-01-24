using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab99 {
    class Amphibian : Pet{
        public Amphibian(PET_TYPE t, PET_COLOR c, string n) : base(t, c, n) { }
        public override string WhenHappy() => "I take my head out of the water";
        public override string Sound() => "ribbit";
        public override string ToString() => $"{base.ToString()} I say {Sound()}, and when I am happy {WhenHappy()}.";
    }
}
