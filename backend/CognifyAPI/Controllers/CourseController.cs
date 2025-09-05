using CognifyAPI.Commands.CourseCommands.CreateCourse;
using CognifyAPI.Dtos.Course;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CognifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ISender _sender;
        public CourseController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(CreateCourseCommand command)
        {
            var course = await _sender.Send(command);

            return Ok(course);
        }
    }
}
