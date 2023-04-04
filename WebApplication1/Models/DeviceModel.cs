using WebApplication1.Entities;

namespace WebApplication1.Models
{
    public class DeviceModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? RegionId { get; set; }

        public virtual ICollection<Event> Events { get; } = new List<Event>();

        public virtual Region? Region { get; set; }
    }
}
