using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToolTime.Data;
using ToolTime.Models;

namespace ToolTime.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckoutRecordsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CheckoutRecordsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CheckoutTool([FromBody] CheckoutRecord record)
        {
            if (!_context.Tools.Any(t => t.Id == record.ToolId))
            {
                return NotFound("Tool Not Found");
            }
            record.CheckoutDateTime = DateTime.UtcNow;
            _context.CheckoutRecords.Add(record);
            _context.SaveChanges();

            return Ok(record);
        }

        [HttpPost("{id}/return")]
        [Authorize(Roles = "Admin")]
        public IActionResult ReturnTool(int id, [FromHeader(Name = "X-User-Id")] string userId)
        {
            var record = _context.CheckoutRecords.FirstOrDefault(t => t.Id == id && t.UserId == userId);
            if (record == null)
            {
                return NotFound("Record not found for this tool and user");
            }
            if (record.ActualReturn != null)
            {
                return BadRequest("Already returned");
            }

            record.ActualReturn = DateTime.UtcNow;
            _context.SaveChanges();

            return Ok(record);
        }

        [Authorize]
        [HttpGet("active")]
        public IActionResult GetActiveCheckouts()
        {
            var checkoutRecords = _context.CheckoutRecords
                .Where(r => r.ActualReturn == null)
                .Include(r => r.Tool)
                .Select(r => new
                {
                    r.Id,
                    Tool = r.Tool.Name,
                    r.ToolId,
                    r.CheckoutDateTime,
                    r.ExpectedReturnDateTime,
                    r.UserId
                }).ToList();

            return Ok(checkoutRecords);
        }
    }
}
