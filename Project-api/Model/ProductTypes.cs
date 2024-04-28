using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project_api.Model
{
    public class ProductTypes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProductType { get; set; }
        public string? ProductTypeName { get; set; }
    }
}
