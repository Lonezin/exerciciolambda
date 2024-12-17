namespace Exercicio.Entities
{
    public class Product
    {
        public double Price { get; set; }
        public string Name { get; set; }

        public Product(string name, double price)
        {
            Price = price;
            Name = name;
        }
    }
}