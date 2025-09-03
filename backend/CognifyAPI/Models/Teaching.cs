namespace CognifyAPI.Models
{
    public class Teaching
    {
        public int LecturerId { get; set; }
        public int CourseId { get; set; }
        public Lecturer LecturerDetails { get; set; }
        public Course CourseDetails { get; set; }
    }
}
