using DemoVerificationOTP.Entities;

namespace DemoVerificationOTP.Services.Interfaces
{
    public interface IBaseService
    {
        public Student FindStudentById(int id);
        public Student FindStudentByEmail(string email);
        public void GenerateOtp(string email);
        public bool VerifyOtp(int id, string otp);
    }
}
