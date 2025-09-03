namespace CognifyAPI.Models
{
    public enum AdminTypes
    {
        SuperAdmin,
        Admin,
        Moderator
    }
    public class Admin
    {
        public int UserId { get; set; }
        public AdminTypes? AdminType { get; set; }
        public User UserDetails { get; set; }
    }
}
