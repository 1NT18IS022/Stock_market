using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_stock_market.Models
{
    public class Stock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ref_id { get; set; }

        [Required(ErrorMessage ="Enter stock prize")]
        public float Stock_price { get; set; }

        
        public DateTime Date_time { get; set; } = DateTime.Now;     

        [Required(ErrorMessage = "enter company code")]
        [ForeignKey("Company")]
        public int Company_code { get; set; }

     
    }
}
