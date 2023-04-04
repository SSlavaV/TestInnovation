using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Security.Claims;
using System.Text.Json.Nodes;
using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class DeviceController : Controller
    {
        [Authorize]
        [HttpGet("getevents")]
        public IActionResult GetEvents([FromServices]InnovationContext innovationContext)
        {
            var events = innovationContext.Events.ToArray();
            return Ok(events);
        }
        
        [HttpPost("create")]
        public IActionResult Create([FromBody] DeviceRegisterModel deviceReg,[FromServices]InnovationContext innovationContext)
        {
            Device device = new()
            {
                Name = deviceReg.Name,
                RegionId = deviceReg.RegionId,
                Token = deviceReg.Token
            };
            innovationContext.Add(device);
            innovationContext.SaveChanges();
            return Ok(device);
        }
        [Authorize]
        [HttpPost("registerEvent")]
        public IActionResult RegisterEvent([FromBody]JsonObject deviceEvent, [FromServices] InnovationContext innovationContext) {
            var evvent = new Event
            {
                DeviceId = int.Parse(User.Claims.First(item => item.Type == ClaimTypes.NameIdentifier).Value),
                Date = DateTimeOffset.Now,
                Value = deviceEvent.ToJsonString()
            };
            innovationContext.Add(evvent);
            innovationContext.SaveChanges();
            return Ok(deviceEvent);
        }
        
    }
}
