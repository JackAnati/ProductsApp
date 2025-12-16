using System.ComponentModel.DataAnnotations;

namespace ProductApp.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ?Name { get; set; }
        public string ?Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
