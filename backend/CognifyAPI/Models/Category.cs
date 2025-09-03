namespace CognifyAPI.Models
{
    public class Category
    {
        public int Id {get; set; }
        public string Title { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
