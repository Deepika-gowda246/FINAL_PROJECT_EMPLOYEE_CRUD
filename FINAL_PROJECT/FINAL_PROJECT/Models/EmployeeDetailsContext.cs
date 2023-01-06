using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FINAL_PROJECT.Models;

public partial class EmployeeDetailsContext : DbContext
{
    
    public EmployeeDetailsContext(DbContextOptions<EmployeeDetailsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF1A8086654");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.Band)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Designation)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Employee_Name");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(5000)
                .IsUnicode(false);
            entity.Property(e => e.Responsibilities)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
