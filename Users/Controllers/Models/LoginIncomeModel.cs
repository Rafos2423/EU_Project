using System.ComponentModel.DataAnnotations;

namespace Users.Controllers.Models
{
    public class LoginIncomeModel
    {
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
