using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÖvningarLinq
{
    internal static class StringHelper
    {
        public static string ChooseOne(List<string> strings)
        {
            Random random = new Random();
            int index = random.Next(0, strings.Count);

            return strings.ElementAt(index);
        }
    }
}
