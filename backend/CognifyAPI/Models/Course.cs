namespace CognifyAPI.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TumbnailUrl { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public Category CategoryDetails { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Teaching> Teachers { get; set; }
        public ICollection<Resource> Resources { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
    }
}
