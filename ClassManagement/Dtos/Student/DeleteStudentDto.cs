using Microsoft.AspNetCore.Mvc;

namespace DemoVerificationOTP.Dtos.Student
{
    public class DeleteStudentDto
    {
        [FromQuery(Name = "Id")]
        public int Id { get; set; }
    }
}
