namespace CognifyAPI.Models
{
    public class Enrollment
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public double Progress { get; set; }
        public DateTime EntrolledDate { get; set; }
        public Student StudentDetails { get; set; }
        public Course CourseDetails { get; set; }
    }
}
