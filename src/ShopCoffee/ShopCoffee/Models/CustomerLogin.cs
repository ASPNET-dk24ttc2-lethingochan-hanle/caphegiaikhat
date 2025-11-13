using System.ComponentModel.DataAnnotations;

namespace ShopCoffee.Models
{
    public class CustomerLogin
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "*")]
        public string Email { get; set; } = null!;

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "*")]
        public string Password { get; set; } = null!;
    }

}
