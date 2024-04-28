using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project_api.Model
{
    public class Games : Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdGame { get; set; }
        public string? GameName { get; set; }
        public string? Genre { get; set; }
        public new float Price { get; set; }
    }
}
