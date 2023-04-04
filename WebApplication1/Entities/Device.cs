using System;
using System.Collections.Generic;

namespace WebApplication1.Entities;

public partial class Device
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? RegionId { get; set; }

    public virtual ICollection<Event> Events { get; } = new List<Event>();

    public virtual Region? Region { get; set; }

    public string? Token { get; set; }
}
