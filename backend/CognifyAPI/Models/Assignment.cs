namespace CognifyAPI.Models
{
    public enum AssigmentStatus
    {
        Active,
        Inactive,
        Completed
    } 
    public class Assignment
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Type { get; set; }
        public AssigmentStatus? Status { get; set; }
        public List<string> AcceptingFileType { get; set; }
        public Course CourseDetails { get; set; }
    }
}
