using WebApplication1.Entities;

namespace WebApplication1.Models
{
    public class DeviceRegisterModel
    {
        public string? Name { get; set; }

        public int? RegionId { get; set; }

        public string? Token { get; set; }
    }
}
