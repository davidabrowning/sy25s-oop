using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiggeBibliotek
{
    class EBook : Book
    {
        public EBook(int ebookIsbn) : base(ebookIsbn)
        {

        }
        public EBook(int isbn, string publisher) : this(isbn)
        {
            Console.WriteLine("publisher is " + publisher);
        } 

        public void PrintIsbn()
        {
            Console.WriteLine(isbn);
        }
    }
}
