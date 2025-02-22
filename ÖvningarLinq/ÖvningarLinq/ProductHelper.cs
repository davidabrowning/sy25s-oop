using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÖvningarLinq
{
    internal static class ProductHelper
    {
        public static List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product("Bananas", "Perishable"));
            products.Add(new Product("Paper towels", "Supplies"));
            products.Add(new Product("Table", "Furniture"));
            products.Add(new Product("Couch", "Furniture"));
            products.Add(new Product("Headset", "IT"));
            products.Add(new Product("Laptop", "IT"));
            products.Add(new Product("Docking station", "IT"));
            products.Add(new Product("Desk", "Furniture"));
            products.Add(new Product("Office chair", "Furniture"));
            products.Add(new Product("Coffee beans", "Perishable"));
            products.Add(new Product("Napkins", "Supplies"));
            products.Add(new Product("Printer", "IT"));
            products.Add(new Product("Projector", "IT"));
            return products;
        }

        public static void PrintProducts(string title, List<Product> products)
        {
            Console.WriteLine($"\n{title}");
            foreach (Product product in products)
            {
                Console.WriteLine(product);
            }
        }
    }
}
