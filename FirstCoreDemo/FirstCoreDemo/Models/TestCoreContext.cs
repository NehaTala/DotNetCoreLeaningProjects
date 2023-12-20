using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FirstCoreDemo.Models;

public partial class TestCoreContext : DbContext
{
    public TestCoreContext()
    {
    }

    public TestCoreContext(DbContextOptions<TestCoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblRole> TblRoles { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DemoDBConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblRole>(entity =>
        {
            entity.HasKey(e => e.PkRoleId).HasName("PK__tbl_Role__B09F5C297088AD8F");

            entity.ToTable("tbl_Roles");

            entity.Property(e => e.PkRoleId).HasColumnName("PK_RoleID");
            entity.Property(e => e.RoleName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.PkUserId).HasName("PK__tbl_User__7C1FCE5FCD744D18");

            entity.ToTable("tbl_User");

            entity.Property(e => e.PkUserId).HasColumnName("PK_UserID");
            entity.Property(e => e.EmailId)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("EmailID");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
