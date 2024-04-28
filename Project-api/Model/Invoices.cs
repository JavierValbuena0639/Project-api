using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project_api.Model
{
    public class Invoices
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdInvoice { get; set; }
        public int IdClient { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }

        // Foreign Key to Client
        [ForeignKey("IdClient")]
        public required Clients Client { get; set; }

        // One-to-Many relationship with DetailInvoice
        public required ICollection<DetailInvoices> DetailInvoices { get; set; }
    }
}
