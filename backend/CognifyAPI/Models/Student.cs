namespace CognifyAPI.Models
{

    public class Student
    {
        public string UserId { get; set; }
        public string Gender { get; set; }
        public int TotalCoursesEnrolled { get; set; }
        public ApplicationUser UserDetails { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
