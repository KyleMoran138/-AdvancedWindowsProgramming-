using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab99 {
    class Cat : Pet{
        public Cat(PET_TYPE t, PET_COLOR c, string n) : base(t, c, n) { }
        public override string WhenHappy() => "I purr";
        public override string Sound() => "Meow";
        public override string ToString() => $"{base.ToString()} I say {Sound()}, and when I am happy {WhenHappy()}.";
    }
}
