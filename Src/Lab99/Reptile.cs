using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab99 {
    class Reptile : Pet {
        public Reptile(PET_TYPE t, PET_COLOR c, string n) : base(t, c, n) { }
        public override string WhenHappy() => "I raise my head up.";
        public override string Sound() => "hiss";
        public override string ToString() {
            return string.Format("{0} I say {1}, and when I am happy {2}.", base.ToString(), Sound(), WhenHappy());
        }
    }
}
