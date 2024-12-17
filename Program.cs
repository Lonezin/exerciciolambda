using Exercicio.Entities;
using System.Globalization;
namespace Exercicio
{

    class Program
    {
        public static void Main(string[] args)
        {
            System.Console.Write("Enter the full file path: ");
            string path = Console.ReadLine();
            
            var list = new List<Product>();

            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] field = sr.ReadLine().Split(',');
                    string name = field[0];
                    double price = double.Parse(field[1],CultureInfo.InvariantCulture);
                    list.Add(new Product(name, price));
                }
            }

            var media = list.Select(p => p.Price).DefaultIfEmpty(0.0).Average();
            Console.WriteLine($"Average Price: {media.ToString("F2")}");
            var names = list.Where(p => p.Price <= media).OrderByDescending(p => p.Name).Select(p => p.Name);
            foreach (var namesInList in names)
            {
                Console.WriteLine(namesInList);
            }

        }
    }
}

