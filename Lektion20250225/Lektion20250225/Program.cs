namespace Lektion20250225
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintAndCompare("A", "B");
            PrintAndCompare("Hej", "Hej");
            PrintAndCompare("Hej", "hej");
            PrintAndCompare(1, 1);
            PrintAndCompare(1, 2);

            CustomList<decimal> myList = new CustomList<decimal>();
            myList.Add(1.1m);
            myList.Add(4);
            myList.Add(5);
            myList.ShowAll();

            Console.WriteLine("Compare tester");
            CustomList<string> aliLista = new CustomList<string>();
            aliLista.Add("Hej");
            aliLista.Add("Hej");
            // Console.WriteLine(aliLista.Compare("Hej", "Hej"));
            //Console.WriteLine(aliLista.Compare(aliLista.Get(0), aliLista.Get(1)));
            Console.WriteLine(aliLista.CompareAtIndex(0, 1));
        }

        private static void PrintAndCompare<T>(T firstValue, T secondValue)
            => Console.WriteLine($"{firstValue} == {secondValue} : {CompareValues(firstValue, secondValue)}");
        private static bool CompareValues<T>(T firstValue, T secondValue) => Equals(firstValue, secondValue);
    }

    internal class CustomList<T>
    {
        private List<T> items;
        public CustomList() => items = new List<T>();
        public void Add(T item) => items.Add(item);
        public T Get(int index) => items[index];
        public void ShowAll()
        {
            int counter = 0;
            foreach (T item in items)
                Console.Write(counter++ + ". " + item.ToString() + "  ");
            Console.WriteLine();
        }
        public bool Compare(T firstValue, T secondValue) => Equals(firstValue, secondValue);
        public bool CompareAtIndex(int firstIndex, int secondIndex) => Compare(Get(firstIndex), Get(secondIndex));
    }

    internal class Storage<T>
    {
        private T item;
        public void StoreItem(T item) => this.item = item;
        public T GetItem() => item;
    }
}
