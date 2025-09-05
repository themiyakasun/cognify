using CognifyAPI.Interfaces;
using CognifyAPI.Models;
using MediatR;

namespace CognifyAPI.Commands.CourseCommands.EnrollCourse
{
    public class EnrollCourseCommandHandler : IRequestHandler<EnrollCourseCommand, Enrollment>
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        public EnrollCourseCommandHandler(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }
        public async Task<Enrollment> Handle(EnrollCourseCommand request, CancellationToken cancellationToken)
        {
            var enrollment = new Enrollment
            {
                CourseId = request.requestDto.CourseId,
                StudentId = request.requestDto.StudentId,
            };

            await _enrollmentRepository.CreateAsync(enrollment);

            return enrollment;
        }
    }
}
