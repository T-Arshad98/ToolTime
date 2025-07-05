using Microsoft.AspNetCore.Mvc;
using ToolTime.Data;
using ToolTime.Models;

namespace ToolTime.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ToolController : ControllerBase
    {
        private readonly AppDbContext _context;


        public ToolController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTools()
        {
            var tools = _context.Tools.ToList();
            return Ok(tools);
        }

        [HttpPost]
        public IActionResult AddTool([FromBody] Tool tool) 
        { 
            _context.Tools.Add(tool);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetTools), new {id = tool.Id}, tool);
        }

    }
}
