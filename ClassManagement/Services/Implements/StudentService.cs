using DemoVerificationOTP.DbContexts;
using DemoVerificationOTP.Dtos.Common;
using DemoVerificationOTP.Dtos.Student;
using DemoVerificationOTP.Entities;
using DemoVerificationOTP.Exceptions;
using DemoVerificationOTP.Services.Interfaces;
using System.Data.SqlTypes;
using System.Security.Cryptography;

namespace DemoVerificationOTP.Services.Implements
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IBaseService _baseService;
        private readonly IAuthService _authService;
        public StudentService(ApplicationDbContext dbContext, IBaseService baseService, IAuthService authService)
        {
            _dbContext = dbContext;
            _baseService = baseService;
            _authService = authService;
        }
        public void CreateStudent(CreateStudentDto input)
        {
            var existStudent = _dbContext.Students.FirstOrDefault(stu => stu.Email == input.Email);
            if (existStudent != null)
            {
                throw new UserFriendlyException("Email đăng ký đã tồn tại.");
            }
            else
            {
                byte[] saltBytes = RandomNumberGenerator.GetBytes(64);

                string hashedPassword = _authService.HashPassword(input.Password, saltBytes);
                string base64Salt = Convert.ToBase64String(saltBytes);

                byte[] retrievedSaltBytes = Convert.FromBase64String(base64Salt);



                var newStudent = new Student
                {
                    Email = input.Email,
                    Password = base64Salt,
                    FullName = input.Name,
                    Salt = retrievedSaltBytes,
                    ConfirmPassword = hashedPassword,
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                };

                _dbContext.Students.Add(newStudent);
                _dbContext.SaveChanges();
            };
        }

        public void DeleteStudent(DeleteStudentDto input)
        {
            var existStudent = _baseService.FindStudentById(input.Id);
            if (existStudent != null)
            {
                _dbContext.Students.Remove(existStudent);
                _dbContext.SaveChanges();
            } else
            {
                throw new UserFriendlyException($"Không tồn tại sinh viên có Id: {input.Id}");
            };
        }

        public PageResultDto<StudentDto> GetAll(FilterDto input)
        {
            var result = new PageResultDto<StudentDto>();
            var studentQuery = _dbContext.Students.Select(stu => new StudentDto
            {
                Id = stu.Id,
                Email = stu.Email,
                Password = stu.Password,
                FullName = stu.FullName,
                CreateAt = stu.CreateAt,
                UpdateAt = stu.UpdateAt,
            });

            if (!string.IsNullOrEmpty(input.Keyword))
            {
                studentQuery = studentQuery.Where(stu => stu.FullName.ToLower().Contains(input.Keyword.ToLower()));
            }

            int totalItem = studentQuery.Count();

            studentQuery = studentQuery.Skip(input.SkipCount()).Take(input.PageSize);

            result.Items = studentQuery;
            result.TotalItem = totalItem;

            return result;
        }

        public Student GetById(int id)
        {
            var existStudent = _baseService.FindStudentById(id);
            if (existStudent != null)
            {
                return existStudent;
            }
            else
            {
                throw new UserFriendlyException($"Không tồn tại sinh viên có Id: {id}");
            }
        }

        public void UpdateStudent(UpdateStudentDto input)
        {
            var existStudent = _baseService.FindStudentById(input.Id);
            if (existStudent != null)
            {
                string hashedPassword = _authService.HashPassword(input.Password, existStudent.Salt);

                existStudent.Email = input.Email;
                existStudent.ConfirmPassword = hashedPassword;
                existStudent.FullName = input.Name;
                existStudent.UpdateAt = DateTime.Now;

                _dbContext.SaveChanges();
            }
            else
            {
                throw new UserFriendlyException($"Không tồn tại sinh viên có Id: {input.Id}");
            }
        }
    }
}
