using GildedRoseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****************************");
            Console.WriteLine("Inventory Management System");
            Console.WriteLine("****************************");
            InventoryManagement inventoryManagement = new InventoryManagement();
            Console.WriteLine("Inventory List");
            EmptyLine();
            Columns(); //Console.WriteLine(string.Format("{0,-20}{1,5}{2,10}", "Item", "SellIn", "Quality"));
            foreach (var inventory in inventoryManagement.Inventories.Value)
            {
                Console.WriteLine(string.Format("{0,-20}{1,5}{2,10}", inventory.Item.Name,
                    inventory.SellIn,
                    inventory.Quality));
            }
            EndListLine();
            bool valid = false;
            string value = "";
            string exit = "";
            do
            {
                Console.WriteLine(@"Enter 'DayEnd' to view end of the day results");
                value = Console.ReadLine()?.ToLower();
                valid = value == "dayend";
                while (valid && exit != "exit")
                {
                    inventoryManagement.Adjust();
                    EmptyLine();
                    Console.WriteLine("Updated Inventory List");
                    EmptyLine();
                    Columns();//Console.WriteLine(string.Format("{0,-20}{1,5}{2,10}", "Item", "SellIn", "Value"));
                    foreach (var inventory in inventoryManagement.Inventories.Value)
                    {
                        Console.WriteLine(string.Format("{0,-20}{1,5}{2,10}",
                            (!string.IsNullOrEmpty(inventory.Item.Error) &&
                             !string.IsNullOrWhiteSpace(inventory.Item.Error))
                                ? inventory.Item.Error
                                : inventory.Item.Name,
                            inventory.SellIn,
                            inventory.Quality));
                    }
                    EndListLine();
                    Console.WriteLine(@"Enter 'Exit' to close application");
                    exit = Console.ReadLine()?.ToLower();
                }
            } while (!valid);
        }

        private static void Columns() { Console.WriteLine(string.Format("{0,-20}{1,5}{2,10}", "Item", "SellIn", "Quality")); }
        private static void EmptyLine() { Console.WriteLine("----------------------------"); }

        private static void EndListLine() { Console.WriteLine("--------End of List---------"); }
    }
}
