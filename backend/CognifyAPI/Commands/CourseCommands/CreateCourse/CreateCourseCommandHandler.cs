using CognifyAPI.Interfaces;
using CognifyAPI.Models;
using MediatR;

namespace CognifyAPI.Commands.CourseCommands.CreateCourse
{
    public class CreateCourseCommandHandler: IRequestHandler<CreateCourseCommand, Course>
    {
            private readonly ICourseRepository _courseRepository;
            public CreateCourseCommandHandler(ICourseRepository courseRepository)
            {
                _courseRepository = courseRepository;
            }
            public async Task<Course> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
            {
                var course = new Course
                {
                    Title = request.requestDto.Title,
                    Description = request.requestDto.Description,
                    TumbnailUrl = request.requestDto.TumbnailUrl,
                    CategoryId = request.requestDto.CategoryId
                };

                var result = await _courseRepository.CreateAsync(course);

                return result;
            }
        
    }
}
