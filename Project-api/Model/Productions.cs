using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project_api.Model
{
    public class Productions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProduction { get; set; } // Elimina este campo
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public DateTime ProductionDate { get; set; }

        // Foreign Key to Product
        [ForeignKey("ProductID")]
        public required Products IdProduct { get; set; }
    }
}
