using Interview.API.Models;
using Interview.API.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Interview.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepo _studentRepo;

        public StudentController(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudent(int id)
        {
           return Ok(await _studentRepo.GetStudent(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(Student student)
        {
            return Ok(await _studentRepo.AddStudent(student));
        }
    }
}
