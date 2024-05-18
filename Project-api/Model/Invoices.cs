using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_api.Model
{
    public class Invoices
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdInvoice { get; set; }

        public int ClientID { get; set; }

        public DateTime InvoiceDate { get; set; }

        public decimal TotalAmount { get; set; }

        // Relación con el cliente (uno a uno)
        [ForeignKey("ClientID")]
        public required Clients IdClient { get; set; }
    }
}
