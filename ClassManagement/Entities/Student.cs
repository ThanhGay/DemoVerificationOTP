using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoVerificationOTP.Entities
{
    [Table("Student")]
    public class Student
    {
        private string _name;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FullName { get => _name; set => _name = value.Trim(); }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string? OTP { get; set; }
        public required string ConfirmPassword { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public required byte[] Salt { get; set; }

    }
}
