using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace Project_api.Model
{
    public class Games 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdGame { get; set; }
        public string? Level { get; set; }
        public int? UserId { get; set; }
        public string? Points { get; set; }
        public string? Time { get; set; }

        [ForeignKey("UserId")]
        public required virtual Users IdUser { get; set; }
    }
}
