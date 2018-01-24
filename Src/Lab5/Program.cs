using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5 {
    class badNumberException : Exception {
        public badNumberException()
            : base("badNumberException thrown!") { }
        public badNumberException(string msg)
            : base(msg) { }
        public badNumberException(string msg, Exception inner)
            : base(msg, inner) { }
    }
    class numberClass{
        public numberClass(int number){
            if(number > 10) {
                throw new badNumberException($"Number {number} is invalid. Number must be less that on equal to 10.");
            }
            Console.WriteLine($"Number {number} is valid");
        }
    }

    class Program {
        static void Main(string[] args) {
            try {
                new numberClass(5);
                new numberClass(11);
            }catch(badNumberException ex) {
                Console.WriteLine(ex.Message + "\n");
            }
            
            Console.WriteLine("Program ended successfully.\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
