namespace ASPCoreApplication2023.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public MembershipType? MembershipType { get; set; }
        public ICollection<Movie>? Movies { get; set; }
    }
}