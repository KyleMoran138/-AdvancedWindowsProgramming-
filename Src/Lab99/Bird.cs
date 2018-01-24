using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab99 {
    class Bird : Pet{
        public Bird(PET_TYPE t, PET_COLOR c, string n) : base(t, c, n) { }
        public override string WhenHappy() => "I squak.";
        public override string Sound() => "REEK";
        public override string ToString() => $"{base.ToString()} I say {Sound()}, and when I am happy {WhenHappy()}.";
    }
}
