using System.ComponentModel.DataAnnotations;

namespace WebAPI_JWT_Auth_Angular.Models.BindingModel
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}
