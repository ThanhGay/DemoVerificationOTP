using DemoVerificationOTP.Dtos.Common;
using DemoVerificationOTP.Dtos.Student;
using DemoVerificationOTP.Entities;

namespace DemoVerificationOTP.Services.Interfaces
{
    public interface IStudentService
    {
        public PageResultDto<StudentDto> GetAll(FilterDto input);
        public Student GetById(int id);
        public void CreateStudent(CreateStudentDto input);
        public void UpdateStudent(UpdateStudentDto input);
        public void DeleteStudent(DeleteStudentDto input);
    }
}
