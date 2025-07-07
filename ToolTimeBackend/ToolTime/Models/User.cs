using System.ComponentModel.DataAnnotations;

namespace ToolTime.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; } = string.Empty;

        public required string Username { get; set; } = string.Empty;
        public required string Password { get; set; } = string.Empty;

        public ICollection<UserRole> Roles = new List<UserRole>();
    }
}
