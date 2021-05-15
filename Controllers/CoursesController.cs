using Microsoft.AspNetCore.Mvc;

namespace CourseApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        // GET: api/Courses
        [HttpGet]
        public string GetCourses()
        {
            return "{}";
        }
    }
}
