using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1 {
    class Program {
        static void Main(string[] args) {
            Invoice[] invoices = {
                new Invoice(83, "Electric sander", 7, 57.98M),
                new Invoice(24, "Power saw", 18, 99.99M),
                new Invoice(7, "Sledge Hammer", 11, 21.5M),
                new Invoice(77, "Hammer", 76, 11.99M),
                new Invoice(39, "Lawn Mower", 3, 79.5M),
                new Invoice(68, "Screwdriver", 106, 6.99M),
                new Invoice(56, "Jig saw", 21, 11M),
                new Invoice(3, "Wrench", 34, 7.5M)
            };

            var sortedByDescription =
                from item in invoices
                orderby item.PartDescription
                select item;

            displayInvoiceArray("Sorted by description: ", sortedByDescription.ToArray());

            var sortedByPrice =
                from item in invoices
                orderby item.Price
                select item;

            displayInvoiceArray("Sorted by price: ", sortedByPrice.ToArray());


            var sortedByDescriptionAndQuantity =
                from item in invoices
                orderby item.PartDescription
                orderby item.Quantity
                select new { item.PartDescription, item.Quantity };

            displayObjectArray("Sorted by description and quantity: ", sortedByDescriptionAndQuantity.ToArray());

            var sortedByDescriptionAndTotal =
                from item in invoices
                orderby item.PartDescription
                orderby item.Quantity * item.Price
                select new { item.PartDescription, InvoiceTotal = (item.Quantity * item.Price) };

            displayObjectArray("Description and invoice total, sort by invoice total:", sortedByDescriptionAndTotal.ToArray());

            var sortedByDescriptionAndTotalInRange =
                from item in invoices
                orderby item.PartDescription
                orderby item.Quantity * item.Price
                where (item.Quantity * item.Price) >= 200 && (item.Quantity * item.Price) <= 500
                select new { item.PartDescription, InvoiceTotal = (item.Quantity * item.Price) };

            displayObjectArray("Invoice totals between $200.00 and $500.00:", sortedByDescriptionAndTotalInRange.ToArray());





            Console.ReadKey(); 
        }

        

        public static void displayInvoiceArray(String title, Invoice[] array){
            Console.WriteLine(title);
            foreach(Invoice i in array) {
                Console.WriteLine(i.ToString());
            }
            Console.WriteLine("\n");
        }

        public static void displayObjectArray(String title , Object[] array) {
            Console.WriteLine(title);
            foreach (Object i in array) {
                Console.WriteLine(i.ToString());
            }
            Console.WriteLine("\n");
        }

    }
}
