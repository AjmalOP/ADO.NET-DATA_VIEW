using ADO.NET_DATA_VIEW.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADO.NET_DATA_VIEW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet("Sort")]
        public IActionResult Sorting()
        {
            return Ok(_studentService.SortStudents());
        }
        [HttpGet("Filter")]
        public IActionResult Filtering()
        {
            return Ok(_studentService.FilterStudent());
        }
    }
}
