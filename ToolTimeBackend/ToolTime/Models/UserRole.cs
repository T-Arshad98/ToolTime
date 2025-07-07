namespace ToolTime.Models
{
    public class UserRole
    {
        public string UserId { get; set; } = string.Empty;

        public User? User { get; set; }

        public string RoleName { get; set; } = string.Empty;
    }
}
