namespace CognifyAPI.Models
{
    public class Lecturer
    {
        public int UserId { get; set; }
        public string Speciality { get; set; }
        public int ContactNumber { get; set; }
        public string LinkedinUrl { get; set; }
        public string WebsiteUrl { get; set; }
        public int TotalCoursesTaught { get; set; }
        public double RatingAverage { get; set; }
        public User UserDetails { get; set; }
        public ICollection<Teaching> Teachings { get; set; }
    }
}
