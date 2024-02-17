using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models;

public partial class ArijitDbContext : DbContext
{
    public ArijitDbContext()
    {
    }

    public ArijitDbContext(DbContextOptions<ArijitDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Register> Registers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ARIJIT\\SQLEXPRESS;Database=arijit_db;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Register>(entity =>
        {
            entity.ToTable("Register");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CorresAddress)
                .HasMaxLength(70)
                .HasColumnName("corres_address");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.EnrollDate).HasColumnName("enroll_date");
            entity.Property(e => e.EnrollNo)
                .HasMaxLength(50)
                .HasColumnName("enroll_no");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("gender");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .HasColumnName("middle_name");
            entity.Property(e => e.MobileNo)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("mobile_no");
            entity.Property(e => e.Password)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNoOffice)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("phone_no_office");
            entity.Property(e => e.PhoneNoRes)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("phone_no_res");
            entity.Property(e => e.Pincode)
                .HasMaxLength(10)
                .HasColumnName("pincode");
            entity.Property(e => e.TypeOfPerson)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("type_of_person");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
