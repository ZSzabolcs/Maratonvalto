using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ZelenakSz_13.A_maratonvalto.Models;

public partial class MaratonContext : DbContext
{
    public MaratonContext()
    {
    }

    public MaratonContext(DbContextOptions<MaratonContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Eredmenyek> Eredmenyek { get; set; }

    public virtual DbSet<Futok> Futok { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;database=maraton;user=root;password=;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Eredmenyek>(entity =>
        {
            entity.HasKey(e => new { e.Futo, e.Kor }).HasName("PRIMARY");

            entity.ToTable("eredmenyek");

            entity.Property(e => e.Futo)
                .HasColumnType("int(11)")
                .HasColumnName("futo");
            entity.Property(e => e.Kor)
                .HasColumnType("int(11)")
                .HasColumnName("kor");
            entity.Property(e => e.Ido)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("ido");

            entity.HasOne(d => d.FutoNavigation).WithMany(p => p.Eredmenyek)
                .HasForeignKey(d => d.Futo)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("eredmenyek_ibfk_1");
        });

        modelBuilder.Entity<Futok>(entity =>
        {
            entity.HasKey(e => e.Fid).HasName("PRIMARY");

            entity.ToTable("futok");

            entity.Property(e => e.Fid)
                .HasColumnType("int(11)")
                .HasColumnName("fid");
            entity.Property(e => e.Csapat)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("csapat");
            entity.Property(e => e.Ffi)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("ffi");
            entity.Property(e => e.Fnev)
                .HasMaxLength(30)
                .HasDefaultValueSql("'NULL'")
                .IsFixedLength()
                .HasColumnName("fnev");
            entity.Property(e => e.Szulev)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("szulev");
            entity.Property(e => e.Szulho)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("szulho");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
