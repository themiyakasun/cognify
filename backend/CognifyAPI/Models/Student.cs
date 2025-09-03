namespace CognifyAPI.Models
{

    public class Student
    {
        public int UserId { get; set; }
        public string Gender { get; set; }
        public int TotalCoursesEnrolled { get; set; }
        public User UserDetails { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
