using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegionController : Controller
    {
        [HttpPost("create")]
        public IActionResult Create([FromBody] RegionRegisterModel regionReg, [FromServices] InnovationContext innovationContext)
        {
            Region region = new()
            {
                Name = regionReg.Name
            };
            innovationContext.Add(region);
            innovationContext.SaveChanges();
            return Ok(region);
        }
    }
}
