using DemoVerificationOTP.DbContexts;
using DemoVerificationOTP.Dtos.FormLogin;
using DemoVerificationOTP.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace DemoVerificationOTP.Services.Implements
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IBaseService _baseService;

        private int wrongOTP = 0;
        private readonly int keySize = 64;
        private readonly int iterations = 350000;
        private readonly HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        public AuthService(ApplicationDbContext dbContext, IBaseService baseService) {
            _dbContext = dbContext;
            _baseService = baseService;
        }
        public void DefaultLogin(DefaultLoginDto input)
        {
            var existAccount = _baseService.FindStudentByEmail(input.Email);
            var truePassword = VerifyPassword(existAccount.Id, input.Password);
            if (truePassword)
            {
                _baseService.GenerateOtp(input.Email);

            }
            else
            {
                throw new Exception("Mật khẩu không chính xác.");
            }
        }
        
        public void LoginWithOtp(LoginWithOTPDto input)
        {
            var existAccount = _baseService.FindStudentByEmail(input.Email);
            var trueOtp = _baseService.VerifyOtp(existAccount.Id, input.Otp);
            if (trueOtp)
            {
                existAccount.OTP = null;
                _dbContext.SaveChanges();
                wrongOTP = 0;
            } 
            else
            {
                wrongOTP += 1;
                if (wrongOTP > 5)
                {
                    existAccount.OTP = null;
                    _dbContext.SaveChanges();
                    wrongOTP = 0;
                    throw new Exception("Sai quá 5 lần. Vui lòng thử lại trong giây lát");
                }
                throw new Exception($"OTP không chính xác. Còn {6 - wrongOTP} lần.");
            }
        }

        public string HashPassword(string password, byte[] salt)
        {
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize);
            return Convert.ToHexString(hash);
        }
        public bool VerifyPassword(int id, string password)
        {
            var student = _baseService.FindStudentById(id);
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, student.Salt, iterations, hashAlgorithm, keySize);
            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(student.ConfirmPassword));
        }
    }
}
  
