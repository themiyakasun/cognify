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
        public string UserId { get; set; }
        public AdminTypes? AdminType { get; set; }
        public ApplicationUser UserDetails { get; set; }
    }
}
