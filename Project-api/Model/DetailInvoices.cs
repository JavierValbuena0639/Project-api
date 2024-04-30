using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project_api.Model
{
    public class DetailInvoices
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDetailInvoice { get; set; }
        public int GameId { get; set; }
        public int StoreId { get; set; }
        public int IdInvoice { get; set; }
        public int IdProduct { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        

        // Foreign Key to Invoice
        [ForeignKey("IdInvoice")]
        public required Invoices Invoice { get; set; }

        // Foreign Key to Product
        [ForeignKey("IdProduct")]
        public required Products Product { get; set; }
        
        // Forein Key to Games
        [ForeignKey("GameId")]
        public required Games IdGame { get; set; }
        
        // Forein Key to Games
        [ForeignKey("GameId")]
        public required Stores IdStore { get; set; }
    }
}
