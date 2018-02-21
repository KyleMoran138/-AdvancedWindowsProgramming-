using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Lab15 {
    class Program {
        

        static void Main(string[] args) {
            string[] array = { "banana", "apple", "peach", "cherry", "strawberry" };
            List<String> fruits = new List<string> { "apple", "passionfruit", "banana", "mango", "grape", "orange", "blueberry", "passionfruit", "strawberry" };
            string[] sites = { "1", "2", "4-8", "3-15" };


            var result = array.OrderBy(a => new string(a.ToCharArray()));
            Display(result, "a) Sort using OrderedBy extension method, then display.");

            IEnumerable<String> arrayReversed = array.Reverse();
            Display(arrayReversed, "b) Reverse sort the string and then display");

            var asc = from st in array orderby st select st;
            Display(asc, "c) Sort in ascending order using LINQ");

            var desc = from st in array orderby st descending select st;
            Display(desc, "d) Sort in decending order using LINQ");

            string[] reversed2 = ReverseEachString(array);
            Display(reversed2, "e) Reverse each string in the array and dsisplay");

            string[] newArr = upperCaseFirstChar(array);
            Display(newArr, "f) for each string, upper case first character");

            var reversed3 = string.Join(" ", array[0]).Split(' ').Select(x => new String(x.Reverse().ToArray()));
            Display(reversed3, "g) reverse word");

            IEnumerable<String> query = fruits.Where(fruit => fruit.Length < 6);
            Display(query, "h) Use of 'where' clause to select fruits with a length less than 6");

            IEnumerable<String> query2 = fruits.Where((num) => num.Contains("e"));
            Display(query2, "i) Use of 'where' clause to select fruits that contain 'e'");

            IEnumerable<String> query3 = fruits.Where((num, index) => num.Contains("e") && index < 6);
            Display(query3, "j) Use of 'where' clause to select fruits that contain e and index < 5");

            IEnumerable<int> squares = Enumerable.Range(1, 10).Select(x => x * x);
            Display(squares, "K) Use 'select' to project over a squence of values and use the index of each element");

            var query4 = fruits.Select((fruit, index) => new { index, str = fruit.Substring(0, index) }); 
            Display(query, "L) Use of 'where' clause to select fruits that contain e and index < 5");

            // SITES

            Console.WriteLine("\n Suppose a copreration has many sites, each identifed by siteIDs.");
            Console.WriteLine("They have various programs that use sites.");
            Console.WriteLine("M) Expand the following sites.");
            string[] expandedSites = ExpandIds(sites);
            sites.ToList().ForEach(x => Console.Write(x + " "));
            Console.WriteLine();

            Console.WriteLine("\nExpanded sites:");
            expandedSites.ToList().ForEach(x => Console.Write(x + " "));

            Console.WriteLine("\n\n\nN) Sites seperated by spaces");
            Console.WriteLine(string.Join(" ", expandedSites));


            Console.WriteLine("\nO) Sites seperated by commas");
            Console.WriteLine(string.Join(", ", expandedSites));

            Console.WriteLine("\nP) Sites are joined");
            Console.WriteLine(string.Join("", expandedSites));

            var str = "1 2334";
            Console.WriteLine($"\nQ) Is this valid numeric string (can have spaces)? {str}");
            isNumOnlyOrWhiteSpace(str);

            str = "12334";
            Console.WriteLine($"\nR) Is this valid numeric string (can have spaces)? {str}");
            isNumOnlyOrWhiteSpace(str);

            str = "123-34";
            Console.WriteLine($"\nS) Is this valid numeric string (can have spaces)? {str}");
            isNumOnlyOrWhiteSpace(str);

            Console.ReadKey();

        }

        private static void isNumOnlyOrWhiteSpace(string str) {
            if (String.IsNullOrEmpty(str)) {
                Console.WriteLine("Null string.");
                return;
            }
            if (str.ToCharArray().All(c => Char.IsNumber(c) || Char.IsWhiteSpace(c))) {
                Console.WriteLine("Valid string. Has all numeric of space characters.");
            }
            else {
                Console.WriteLine("inValid string. Has some non-numeric characters.");
            }
            return;
        }

        private static string[] upperCaseFirstChar(string[] array) {
            
            string[] newStr = new string[array.Length];
            
            for(int i = 0; i < newStr.Length; i++) {
                newStr[i] = string.Format("{0}{1}", char.ToUpper(array[i][0]), array[i].Remove(0, 1));
            }
            return newStr;
        }

        private static string[] ReverseEachString(string[] arr) {
            string[] returnArray = new string[arr.Count()];

            for(int i = 0; i < arr.Length; i++) {
                returnArray[i] = ReverseString(arr[i]);
            }
            return returnArray;
        }

        private static string ReverseString(string v) {
            if (v == null)
                return "";
            char[] r = v.ToCharArray();
            Array.Reverse(r);
            return new string(r);
        }

        public static void Display<T>(IEnumerable<T> str, string msg) {
            Console.WriteLine(msg);
            foreach(var item in str) {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n");
        }

        private static string[] ExpandIds(string[] ids) {
            List<String> result = new List<String>();
            foreach(string part in ids) {
                int i = part.IndexOf('-');
                if(i == -1) {
                    result.Add(part);
                }
                else {
                    string min = part.Substring(0, i);
                    string max = part.Substring(i + 1);
                    int iMin = Convert.ToInt32(min);
                    int iMax = Convert.ToInt32(max);
                    for(i = iMin; i <= iMax; i++) {
                        result.Add(i.ToString());
                    }
                    var noDupes = result.Distinct().ToList().OrderBy(x => int.Parse(x));
                    return noDupes.ToArray<string>();
                }
            }

            return null;
        }
    }
}
