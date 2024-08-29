using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DemoVerificationOTP.Dtos.FormLogin
{
    public class DefaultLoginDto
    {
        private string _email, _password;
        [FromForm(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng nhập email"),
            EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        public string Email { get => _email; set => _email = value.Trim(); }
        [FromForm(Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng nhập mật khẩu"),
            MinLength(6, ErrorMessage = "Mật khẩu tối thiểu 6 ký tự")]
        public string Password { get => _password; set => _password = value.Trim(); }
    }
}
