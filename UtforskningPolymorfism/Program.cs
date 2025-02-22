namespace UtforskningPolymorfism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();
            shapes.Add(new Rectangle(41, 52));
            shapes.Add(new Circle(10));
            foreach (Shape shape in shapes)
            {
                Console.WriteLine(shape);
            }
        }
    }
}
