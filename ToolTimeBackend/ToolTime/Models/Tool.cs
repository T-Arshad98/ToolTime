using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ToolTime.Models
{
    public class Tool
    {
        [Key]
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Type { get; set; }

        public required string SerialNumber { get; set; }

        public string? Description { get; set; }

        public DateTime? LastInspectionDate { get; set; }
    }
}
