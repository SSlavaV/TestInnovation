using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Entities;

public partial class InnovationContext : DbContext
{
    public InnovationContext()
    {
    }

    public InnovationContext(DbContextOptions<InnovationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Device> Devices { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Region> Regions { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Device>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Region).WithMany(p => p.Devices)
                .HasForeignKey(d => d.RegionId)
                .HasConstraintName("FK_Devices_Regions");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Device).WithMany(p => p.Events)
                .HasForeignKey(d => d.DeviceId)
                .HasConstraintName("FK_Events_Devices");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
