using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÖvningarLinq
{
    internal class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public Product(string name, string category)
        {
            Name = name;
            Category = category;
        }
        public override string ToString()
        {
            return $"{Name} ({Category.ToLower()})";
        }
    }
}
