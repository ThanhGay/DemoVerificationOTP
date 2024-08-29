using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DemoVerificationOTP.Dtos.FormLogin
{
    public class LoginWithOTPDto
    {
        private string _email, _otp;
        [FromForm(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng nhập email"),
            EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        public string Email { get => _email; set => _email = value.Trim(); }
        [FromForm(Name = "OTP")]
        [Required(AllowEmptyStrings = false, ErrorMessage ="Vui lòng nhập OTP"), 
            Length(6, 6, ErrorMessage = "Vui lòng nhập OTP bao gồm 6 ký tự")]
        public string Otp { get => _otp; set => _otp = value.Trim(); }
    }
}
