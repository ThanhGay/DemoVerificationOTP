using DemoVerificationOTP.DbContexts;
using DemoVerificationOTP.Entities;
using DemoVerificationOTP.Exceptions;
using DemoVerificationOTP.Services.Interfaces;

namespace DemoVerificationOTP.Services.Implements
{
    public class BaseService : IBaseService
    {
        public readonly ApplicationDbContext _context;
        private readonly INotiService _notiService;
        


        public BaseService(ApplicationDbContext dbContext, INotiService notiService) {
            _context = dbContext;
            _notiService = notiService;
        }
        public Student FindStudentById(int id)
        {
            var existStudent = _context.Students.FirstOrDefault(s => s.Id == id);

            if (existStudent == null)
            {
                throw new UserFriendlyException($"Không tìm thấy sinh viên có Id: {id}");
            }
            return existStudent;
            
        }

        public Student FindStudentByEmail(string email)
        {
            var existStudent = _context.Students.FirstOrDefault(s => s.Email == email);

            if (existStudent == null)
            {
                throw new UserFriendlyException($"Không tìm thấy sinh viên có Email: {email}");
            }
            return existStudent;

        }

        public void GenerateOtp(string email)
        {
            Random rd = new Random();

            var student = FindStudentByEmail(email);
            if (student != null)
            {
                int otpNum = rd.Next(100000, 999999);
                string otpStr = otpNum.ToString();

                _notiService.SendMail(student.Email, "Mã OTP của bạn là: " + otpStr);

                student.OTP = otpStr;
                _context.SaveChanges();
            }
        }

        public bool VerifyOtp(int id, string otp)
        {
            var student = FindStudentById(id);
            return student.OTP == otp;
        }

    }
}
