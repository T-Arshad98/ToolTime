using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToolTime.Data;
using ToolTime.Models;

namespace ToolTime.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaintenanceRequestsController: ControllerBase
    {
        private readonly AppDbContext _context;

        public MaintenanceRequestsController(AppDbContext context)
        {
            _context = context;
        }

        //add new record based on tool

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateRequest([FromBody] MaintenanceRequest request)
        {
            if (!_context.Tools.Any(t => t.Id == request.ToolId))
            {
                return NotFound("Tool not found");
            }

            request.CreatedAt = DateTime.UtcNow;
            request.Status = "Pending";
            _context.MaintenanceRequests.Add(request);
            _context.SaveChanges();
            
            return Ok(request);
        }

        [HttpPost("{id}/resolve")]
        [Authorize(Roles = "Admin")]
        public IActionResult ResolveRequest(int id, [FromHeader(Name = "X-User-Id")] string userId)
        {
            var req = _context.MaintenanceRequests.FirstOrDefault(t => t.Id == id);
            if (req == null) return NotFound("Request not found");

            if (req.Status == "Resolved") return BadRequest("Already resolved");

            req.Status = "Resolved";
            req.ResolvedAt = DateTime.UtcNow;
            _context.SaveChanges();

            return Ok(req);
        }

        [Authorize]
        [HttpGet("active")]
        public IActionResult GetActiveRequests()
        {
            var active = _context.MaintenanceRequests
                .Where(r => r.Status != "Resolved")
                .Include(r => r.Tool)
                .Select(r => new
                {
                    r.Id,
                    Tool = r.Tool.Name,
                    r.ToolId,
                    r.UserId,
                    r.IssueDesc,
                    r.Status,
                    r.CreatedAt,
                    r.ResolvedAt
                }).ToList();

            return Ok(active);
        }
    }
}
