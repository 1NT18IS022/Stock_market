using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_stock_market.Models
{
    public class loginuser
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string UserName { get; set; }=String.Empty;

        public string PasswordHash { get; set; } =String.Empty;

        public string Role { get; set; } = String.Empty;

    }
}
