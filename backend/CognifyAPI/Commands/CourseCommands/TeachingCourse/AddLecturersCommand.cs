using CognifyAPI.Dtos.Course;
using CognifyAPI.Models;
using MediatR;

namespace CognifyAPI.Commands.CourseCommands.TeachingCourse
{
    public record AddLecturersCommand(TeachingPostDto requestDto): IRequest<Teaching>;
}
