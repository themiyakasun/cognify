using CognifyAPI.Dtos.Course;
using CognifyAPI.Models;
using MediatR;

namespace CognifyAPI.Commands.CourseCommands.EnrollCourse
{
    public record EnrollCourseCommand(EnrollmentPostDto requestDto): IRequest<Enrollment>;
}
