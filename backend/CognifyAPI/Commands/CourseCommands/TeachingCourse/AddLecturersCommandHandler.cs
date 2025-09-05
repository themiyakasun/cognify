using CognifyAPI.Interfaces;
using CognifyAPI.Models;
using MediatR;

namespace CognifyAPI.Commands.CourseCommands.TeachingCourse
{
    public class AddLecturersCommandHandler : IRequestHandler<AddLecturersCommand, Teaching>
    {
        private readonly ITeachingRepository _teachingRepository;
        public AddLecturersCommandHandler(ITeachingRepository teachingRepository)
        {
            _teachingRepository = teachingRepository;
        }
        public async Task<Teaching> Handle(AddLecturersCommand request, CancellationToken cancellationToken)
        {
            var teaching = new Teaching
            {
                LecturerId = request.requestDto.LecturerId,
                CourseId = request.requestDto.CourseId
            };

            await _teachingRepository.CreateAsync(teaching);

            return teaching;
        }
    }
}
