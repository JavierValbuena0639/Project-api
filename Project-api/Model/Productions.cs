using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project_api.Model
{
    public class Productions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProduction { get; set; }
        public int IdProduct { get; set; }
        public int Quantity { get; set; }
        public DateTime ProductionDate { get; set; }

        // Foreign Key to Product
        [ForeignKey("IdProduct")]
        public required Products Product { get; set; }

        // Foreign Key to Store (optional)
        public int? IdStore { get; set; }
        [ForeignKey("IdStore")]
        public required StoresRepository Store { get; set; }
    }
}
