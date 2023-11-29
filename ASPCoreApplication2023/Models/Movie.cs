namespace ASPCoreApplication2023.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public Genre? Genre { get; set; }
        public ICollection<Customer>? Customers { get; set; }
    }
}
