using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiggeBibliotek
{
    class Book
    {
        internal int isbn;
        public int Isbn { get { return isbn; } }
        public Book(int isbn)
        {
            this.isbn = isbn;
        }
    }
}
