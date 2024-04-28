using System.ComponentModel.DataAnnotations.Schema;

namespace Project_api.Model
{
    public class Trades
    {
        public int Id { get; set; }
        public int? User_id { get; set; }
        public int? Item_id { get; set; }

        [ForeignKey ("Item_id")]
        public required virtual Product ID { get; set; }
       
        [ForeignKey("User_id")]
        public required virtual Users IdUser { get; set; }
    }
}
