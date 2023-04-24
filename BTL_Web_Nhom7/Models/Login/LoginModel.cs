using System.ComponentModel.DataAnnotations;

namespace BTL_Web_Nhom7.Models.Login
{
    public class LoginModel
    {
        [Required]
        public string ?UserName { get; set; }
        [Required]
        public string ?Password { get; set; }
    }
}
