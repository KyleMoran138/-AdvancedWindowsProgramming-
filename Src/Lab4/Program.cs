using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4 {
    class ExceptionA : Exception {
        public ExceptionA()
            :base("Exception thrown by class ExceptionA") { }
        public ExceptionA(string msg)
            : base(msg) { }
        public ExceptionA(string msg, Exception inner)
            : base(msg, inner) { }
    }
    class ExceptionB : ExceptionA {
        public ExceptionB()
            : base("Exception thrown by class ExceptionB") { }
        public ExceptionB(string msg)
            : base(msg) { }
        public ExceptionB(string msg, Exception inner)
            : base(msg, inner) { }
    }
    class ExceptionC : ExceptionB {
        public ExceptionC()
            : base("Exception thrown by class ExceptionC") { }
        public ExceptionC(string msg)
            : base(msg) { }
        public ExceptionC(string msg, Exception inner)
            : base(msg, inner) { }
    }
    class Program {
        public static void Main(string[] args) {

            // 1
            try {
                Console.WriteLine("\n1) Throw a base class exception, ExceptionA");
                throw new ExceptionA();
            }catch(ExceptionC ex) {
                Console.WriteLine("Caught by catch block that has ExceptionC\n" + ex + "\n");
            }catch(ExceptionB ex) {
                Console.WriteLine("Caught by catch block that has ExceptionC\n" + ex + "\n");
            } catch(ExceptionA ex) {
                Console.WriteLine("Caught by catch block that has ExceptionC\n" + ex + "\n");
            }

            // 2
            try {
                Console.WriteLine("\n\n2) Throw a derived-class ExceptionB");
                throw new ExceptionB();
            }catch(ExceptionA ex) {
                Console.WriteLine("ExceptionB caught in ExceptionA catch block" + ex + "\n");
            }

            // 3
            try {
                Console.WriteLine("\n\n3) About to throw ExceptionC: ");
                throw new ExceptionC("Exception C occured...");
            }catch(ExceptionC ex) {
                Console.WriteLine("Caught by catch block that has ExceptionC\n" + ex + "\n");
            }catch(ExceptionB ex) {
                Console.WriteLine("Caught by catch block that has ExceptionB\n" + ex + "\n");
            }

            // 4
            try {
                Console.WriteLine("\n\n4) InnerException. Calling method that throws Exception.");
                methodThatThrowsException();
                throw new ExceptionC("Exception C occured...");
            }catch (ExceptionC ex) {
                Console.WriteLine("Caught by catch block that has ExceptionC\n" + ex + "\n");
            } catch (ExceptionB ex) {
                Console.WriteLine("Caught by catch block that has ExceptionB\n" + ex + "\n");
            } catch (ExceptionA ex) {
                Console.WriteLine("Caught by catch block that has ExceptionA\n" + ex + "\n");
            }
            Console.WriteLine("\n\nProgramming ended successfully... \nPress any key to continue...");
            Console.ReadKey();
        }
        public static void methodThatThrowsException() {
            try {
                Console.WriteLine("Inside method, about to throw ExceptionC: ");
                throw new ExceptionC("Exception C occurred...");
            } catch (ExceptionC ex) {
                Console.WriteLine("Caught by catch block that has ExceptionC\n" + ex + "\n");
                throw new ExceptionC("Caught exception, re-throwing it back", ex);
            } catch (ExceptionB ex) {
                Console.WriteLine("Caught by catch block that has ExceptionC\n" + ex + "\n");
            } catch (ExceptionA ex) {
                Console.WriteLine("Caught by catch block that has ExceptionC\n" + ex + "\n");
            }
        }
    }
    
}
