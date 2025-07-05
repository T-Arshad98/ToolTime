using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ToolTime.Models
{
    public class Tool
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Type { get; set; }

        [Required]
        public required string SerialNumber { get; set; }

        [AllowNull]
        public string? Description { get; set; }

        [AllowNull]
        public DateTime? LastInspectionDate { get; set; }
    }
}
