using DemoVerificationOTP.Dtos.FormLogin;
using DemoVerificationOTP.Entities;

namespace DemoVerificationOTP.Services.Interfaces
{
    public interface IAuthService
    {
        public void DefaultLogin (DefaultLoginDto input);
        public Student LoginWithOtp(LoginWithOTPDto input);
        public string HashPassword(string password, byte[] salt);
        public bool VerifyPassword(int id, string password);
    }
}
