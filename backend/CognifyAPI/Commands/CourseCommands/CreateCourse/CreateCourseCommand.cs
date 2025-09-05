using CognifyAPI.Dtos.Course;
using CognifyAPI.Models;
using MediatR;

namespace CognifyAPI.Commands.CourseCommands.CreateCourse
{
    public record CreateCourseCommand(CoursePostDto requestDto): IRequest<Course>;
}
