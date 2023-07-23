using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace jwtauth
{
    public class user
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int User_Id { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }
    }
}

