using DemoVerificationOTP.Dtos.Common;
using DemoVerificationOTP.Dtos.Student;
using DemoVerificationOTP.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DemoVerificationOTP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController: ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("get-all")]
        public IActionResult GetAll(FilterDto input)
        {
            try
            {
                return Ok(_studentService.GetAll(input));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-by-id/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_studentService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create")]
        public IActionResult CreateStudent(CreateStudentDto input)
        {
            try
            {
                _studentService.CreateStudent(input);
                return Ok("Thêm thành công.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpDelete("delete")]
        public IActionResult DeleteStudent(DeleteStudentDto input)
        {
            try
            {
                _studentService.DeleteStudent(input);
                return Ok("Xóa thành công.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public IActionResult UpdateStudent(UpdateStudentDto input)
        {
            try
            {
                _studentService.UpdateStudent(input);
                return Ok("Cập nhật thành công");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
