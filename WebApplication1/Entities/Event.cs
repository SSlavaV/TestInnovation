using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace WebApplication1.Entities;

public partial class Event
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTimeOffset? Date { get; set; }

    public int? DeviceId { get; set; }

    public string? Value { get; set; }

    public virtual Device? Device { get; set; }
}
