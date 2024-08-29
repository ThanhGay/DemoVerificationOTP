namespace DemoVerificationOTP.Dtos.Student
{
    public class StudentDto
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public string? Password { get; set; }
        public string? OTP { get; set; }
        public string? ConfirmPassword { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
