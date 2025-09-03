namespace CognifyAPI.Models
{
    public class Resource
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public List<string> Type { get; set; }
        public string Title { get; set; }
        public string ResourceUrl { get; set; }
        public DateTime UploadedAt { get; set; }
        public Course CourseDetails { get; set; }
    }
}
