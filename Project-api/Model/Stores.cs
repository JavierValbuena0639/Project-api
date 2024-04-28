using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Project_api.Model
{
    public class Stores
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdStore { get; set; }
        public string? StoreName { get; set; }
        public string? StoreAddress { get; set; }

        // One-to-Many relationship with Production
        public required ICollection<Productions> Productions { get; set; }
    }
}
