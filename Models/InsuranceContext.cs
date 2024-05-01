using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Insurance.Models;

public partial class InsuranceContext : DbContext
{
    public InsuranceContext()
    {
    }

    public InsuranceContext(DbContextOptions<InsuranceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<insurance> Insurances { get; set; }
    public virtual DbSet<Payment> Payments { get; set; }
    //  public virtual DbSet<Login> Logins { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //        => optionsBuilder.UseSqlServer("Server=LAPTOP-EQOQ7RS0\\MSSQLSERVER01;Database=insurance;Integrated Security=True;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<insurance>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("insurance");

            entity.Property(e => e.EmailId)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("emailId");
            entity.Property(e => e.LoginPassword)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("loginPassword");
        });
        modelBuilder.Entity<Payment>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("insurance");

            entity.Property(e => e.cus_Name)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("cus_Name");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("PaymentId");
            entity.Property(e => e.cardNumber)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("cardNumber");
            entity.Property(e => e.SecurityCode)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("SecurityCode");
            entity.Property(e => e.ExpirationDate)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("ExpirationDate");
        });

        /*modelBuilder.Entity<Login>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("login");

            entity.Property(e => e.EmailId)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("emailId");
            entity.Property(e => e.LoginPassword)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("loginPassword");
        });*/

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
