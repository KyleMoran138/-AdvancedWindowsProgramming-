using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6 {
    class MyException : Exception {
        public MyException()
            : base() { }
        public MyException(string msg)
            : base(msg) { }
        public MyException(string msg, Exception inner)
            :base(msg, inner) { }
    }
    class Program {
        static void Main(string[] args) {
            try {
                methodA();
            }catch(MyException ex) {
                Console.WriteLine("Custom Exception throw from MethodH\n\nThe stack trace for this exception is: \n" + ex.StackTrace);
            }

            Console.WriteLine("Program has ended properly.\nPress any key to continue...");
            Console.ReadKey();
        }
        public static void methodA() {
            methodB();
        }
        public static void methodB() {
            methodC();
        }
        public static void methodC() {
            methodD();
        }
        public static void methodD() {
            methodE();
        }
        public static void methodE() {
            methodF();
        }
        public static void methodF() {
            methodG();
        }
        public static void methodG() {
            methodH();
        }
        public static void methodH() {
            throw new MyException();
        }
    }
}
