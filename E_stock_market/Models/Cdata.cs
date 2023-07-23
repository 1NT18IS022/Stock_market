using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace E_stock_market.Models
{
    public class Cdata
    {
        [Required(ErrorMessage = "Enter company code")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Company_code { get; set; }


        [Required(ErrorMessage = "Please enter company name")]
        public string Company_name { get; set; }
        [Required(ErrorMessage = "Please enter company ceo ")]
        public string Company_ceo { get; set; }
        [Required(ErrorMessage = "Please enter company turnover")]
        public long Company_turnover { get; set; }
        [Required(ErrorMessage = "Please enter company website")]
        [DataType(DataType.Url)]
        public string Company_website { get; set; }
    }
}
