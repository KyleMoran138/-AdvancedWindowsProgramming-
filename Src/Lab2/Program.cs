using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Please enter a sentence:");
            var input = Console.ReadLine();
            Console.WriteLine("\n You entered: \n " + input + "\n");
            Console.Write("Distinct words: ");

            foreach(String s in input.Split().Distinct()) {
                Console.Write(s + " ");
            }

            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();


        }
    }
}
