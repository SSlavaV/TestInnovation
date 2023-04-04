using System;
using System.Collections.Generic;

namespace WebApplication1.Entities;

public partial class Region
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Device> Devices { get; } = new List<Device>();
}
