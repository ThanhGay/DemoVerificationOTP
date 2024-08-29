using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DemoVerificationOTP.Dtos.Student
{
    public class CreateStudentDto
    {
        private string _name, _email, _password;
        [FromQuery(Name="Họ và tên")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Họ tên không được để trống")]
        public required string Name { get => _name; set => _name = value.Trim(); }
        [FromQuery(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng nhập email"),
            EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        public required string Email { get => _email; set => _email = value.Trim(); }
        [FromQuery(Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng nhập mật khẩu"),
            MinLength(6, ErrorMessage = "Mật khẩu tối thiểu 6 ký tự")]
        public required string Password { get => _password; set => _password = value.Trim(); }
    }
}
