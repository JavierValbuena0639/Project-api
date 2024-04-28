using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project_api.Model
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProduct { get; set; }
        public string? TypeProduct { get; set; }
        public string? TypeProductNameProduct { get; set; }
        public int? UnitValue { get; set; }

    }
}