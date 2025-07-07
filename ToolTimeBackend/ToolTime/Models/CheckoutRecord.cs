using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ToolTime.Models
{
    public class CheckoutRecord
    {
        [Key]
        public int Id { get; set; }

        public required int ToolId { get; set; }

        public Tool? Tool { get; set; }

        public required string UserId { get; set; } = string.Empty;

        public User? User { get; set; }

        public DateTime CheckoutDateTime { get; set; }

        public DateTime ExpectedReturnDateTime { get; set; }

        public DateTime? ActualReturn { get; set; } // Nullable in case the tool is still out


    }
}
