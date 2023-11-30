using System.ComponentModel.DataAnnotations.Schema;

namespace ASPCoreApplication2023.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public Genre? Genre { get; set; }
        public ICollection<Customer>? Customers { get; set; }
        public string? Photo { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
