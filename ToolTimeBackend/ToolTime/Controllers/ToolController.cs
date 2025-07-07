using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToolTime.Data;
using ToolTime.Models;

namespace ToolTime.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToolsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ToolsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetTools()
        {
            var tools = _context.Tools.ToList();
            return Ok(tools);
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddTool([FromBody] Tool tool) 
        { 
            _context.Tools.Add(tool);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetTools), new {id = tool.Id}, tool);
        }

    }
}
