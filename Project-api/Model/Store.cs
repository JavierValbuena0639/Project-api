using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project_api.Model
{
    public class Store
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdStore { get; set; }
        public string? NameStore { get; set; }
        public DateTime? DateCreate { get; set; }
        public int? idSell  { get; set; }

    }
}
