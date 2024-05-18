using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project_api.Model
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProduct { get; set; }
        public string? ProductName { get; set; }
        public int ProductTypeID { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        // Foreign Key to ProductType
        [ForeignKey("ProductTypeID")]
        public required ProductTypes IdProductType { get; set; }
    }
}
