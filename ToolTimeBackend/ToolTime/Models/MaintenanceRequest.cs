using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToolTime.Models
{
    public class MaintenanceRequest
    {
        [Key]
        public int Id { get; set; }

        public required int ToolId { get; set; }

        public Tool? Tool{ get; set; }

        public required string UserId { get; set; } = string.Empty;

        public User? User { get; set; }

        public required string IssueDesc { get; set; }

        public required string Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ResolvedAt { get; set; }

    }
}
