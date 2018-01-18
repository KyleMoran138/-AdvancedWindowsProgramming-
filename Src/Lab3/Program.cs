using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3 {
    class Program {
        static char[] chars = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

        static void Main(string[] args) {
            char[] geneList = getRandomCharArray(30);
            Console.WriteLine("Generated List: \n");
            displayCharArray(geneList);

            geneList = geneList.OrderByDescending(x => x).ToArray();
            Console.WriteLine("\n Ascending order: ");
            displayCharArray(geneList.Reverse().ToArray());

            Console.WriteLine("\n Descending order:");
            displayCharArray(geneList.ToArray());

            Console.WriteLine("\n Ascending order, no duplicates:");
            displayCharArray(geneList.Distinct().Reverse().ToArray());

            Console.WriteLine("\n Press any ket to continue...");
            Console.ReadKey();
        }

        //Generates an array of random chars
        // count = # of chars to create
        public static char[] getRandomCharArray(int count) {
            var random = new Random();
            char[] returnArray = new char[count];
            
            for(var i = 0; i < count; i++){
                int randNum = random.Next(0, chars.Length);
                returnArray[i] = chars[randNum];
            }
            return returnArray;
        }

        public static void displayCharArray(char[] array) {
            foreach (char c in array) {
                Console.Write(c + " ");
            }
        }
    }
}
