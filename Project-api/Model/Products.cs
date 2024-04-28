using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Project_api.Model
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProduct { get; set; }
        public string? ProductName { get; set; }
        public int IdProductType { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        // Foreign Key to ProductType
        [ForeignKey("IdProductType")]
        public required ProductTypes ProductType { get; set; }

        // One-to-Many relationship with Production
        public required ICollection<Productions> Productions { get; set; }
    }
}
