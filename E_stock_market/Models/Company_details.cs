using System.ComponentModel.DataAnnotations;

namespace E_stock_market.Models
{
    public class Company_details
    {
        public int Company_code { get; set; }
        
        public string Company_name { get; set; }
        
        public string Company_ceo { get; set; }
      
        public long Company_turnover { get; set; }
       
        public string Company_website { get; set; }

        public float Stock_price { get; set; }
    }
}
