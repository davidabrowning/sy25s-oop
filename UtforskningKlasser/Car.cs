using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtforskningKlasser
{
    public class Car
    {
        public string Make { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }
        public string Color { get; set; }
        public Car(string make, string model, int year, string color)
        {
            Make = make;
            Model = model;
            Year = year;
            Color = color;
        }
        public void ShowInfo()
        {
            StringBuilder info = new StringBuilder();
            info.Append("####################\n");
            info.Append("#                  #\n");
            info.Append("#     Car info     #\n");
            info.Append("#                  #\n");
            info.Append("# ---------------- #\n");
            info.Append("#                  #\n");
            string makeString = $"Make:  {Make}";
            info.Append($"# {AddTrailingSpaces(makeString, 16)} #\n");
            string modelString = $"Model: {Model}";
            info.Append($"# {AddTrailingSpaces(modelString, 16)} #\n");
            string yearString = $"Year:  {Year}";
            info.Append($"# {AddTrailingSpaces(yearString, 16)} #\n");
            string colorString = $"Color: {Color}";
            info.Append($"# {AddTrailingSpaces(colorString, 16)} #\n");
            info.Append("#                  #\n");
            info.Append("####################\n");
            Console.WriteLine(info);
        }
        private string AddTrailingSpaces(string inputString, int targetLength)
        {
            StringBuilder output = new StringBuilder();
            output.Append(inputString);
            for(int i= 0; i < targetLength - inputString.Length; i++)
            {
                output.Append(" ");
            }
            return output.ToString();
        }
    }
}
