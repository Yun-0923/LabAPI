using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using LabAPI.Models;

namespace LabAPI.Models;

public partial class dbLabContext : DbContext
{
    public dbLabContext(DbContextOptions<dbLabContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categories> Categories { get; set; }

    public virtual DbSet<ChemicalOrderDetails> ChemicalOrderDetails { get; set; }

    public virtual DbSet<ChemicalRecords> ChemicalRecords { get; set; }

    public virtual DbSet<Chemicals> Chemicals { get; set; }

    public virtual DbSet<ConsumableOrderDetails> ConsumableOrderDetails { get; set; }

    public virtual DbSet<ConsumableRecords> ConsumableRecords { get; set; }

    public virtual DbSet<Consumables> Consumables { get; set; }

    public virtual DbSet<Employee> Employee { get; set; }

    public virtual DbSet<Orders> Orders { get; set; }

    public virtual DbSet<SampleRecords> SampleRecords { get; set; }

    public virtual DbSet<SampleType> SampleType { get; set; }

    public virtual DbSet<Samples> Samples { get; set; }

    public virtual DbSet<Supplier> Supplier { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categories>(entity =>
        {
            entity.HasKey(e => e.CategoryID).HasName("PK__Categori__19093A2BE233F606");

            entity.Property(e => e.CategoryName).HasMaxLength(30);
        });

        modelBuilder.Entity<ChemicalOrderDetails>(entity =>
        {
            entity.HasKey(e => new { e.OrderID, e.ChemicalID }).HasName("PK__Chemical__BA62C1A048C9C4BC");

            entity.HasOne(d => d.Chemical).WithMany(p => p.ChemicalOrderDetails)
                .HasForeignKey(d => d.ChemicalID)
                .HasConstraintName("FK__ChemicalO__Chemi__66603565");

            entity.HasOne(d => d.Order).WithMany(p => p.ChemicalOrderDetails)
                .HasForeignKey(d => d.OrderID)
                .HasConstraintName("FK__ChemicalO__Order__656C112C");
        });

        modelBuilder.Entity<ChemicalRecords>(entity =>
        {
            entity.HasKey(e => e.RecordID).HasName("PK__Chemical__FBDF78C95F9BD6BF");

            entity.ToTable(tb => tb.HasTrigger("checkChemicalQty"));

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.EmployeeID)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Notes).HasMaxLength(100);

            entity.HasOne(d => d.Chemical).WithMany(p => p.ChemicalRecords)
                .HasForeignKey(d => d.ChemicalID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__ChemicalR__Chemi__44FF419A");

            entity.HasOne(d => d.Employee).WithMany(p => p.ChemicalRecords)
                .HasForeignKey(d => d.EmployeeID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__ChemicalR__Emplo__440B1D61");
        });

        modelBuilder.Entity<Chemicals>(entity =>
        {
            entity.HasKey(e => e.ChemicalID).HasName("PK__Chemical__9F29A0F6418CEC21");

            entity.Property(e => e.CASNo).HasMaxLength(20);
            entity.Property(e => e.CabinetName).HasMaxLength(10);
            entity.Property(e => e.ChineseName).HasMaxLength(60);
            entity.Property(e => e.EnglishName).HasMaxLength(60);

            entity.HasOne(d => d.Category).WithMany(p => p.Chemicals)
                .HasForeignKey(d => d.CategoryID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Chemicals_Categories");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Chemicals)
                .HasForeignKey(d => d.SupplierID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Chemicals__Suppl__412EB0B6");
        });

        modelBuilder.Entity<ConsumableOrderDetails>(entity =>
        {
            entity.HasKey(e => new { e.OrderID, e.ConsumableID }).HasName("PK__Consumab__B69EBA82B9A2CB6F");

            entity.HasOne(d => d.Consumable).WithMany(p => p.ConsumableOrderDetails)
                .HasForeignKey(d => d.ConsumableID)
                .HasConstraintName("FK__Consumabl__Consu__628FA481");

            entity.HasOne(d => d.Order).WithMany(p => p.ConsumableOrderDetails)
                .HasForeignKey(d => d.OrderID)
                .HasConstraintName("FK__Consumabl__Order__619B8048");
        });

        modelBuilder.Entity<ConsumableRecords>(entity =>
        {
            entity.HasKey(e => e.RecordID).HasName("PK__Consumab__FBDF78C9AB678102");

            entity.ToTable(tb => tb.HasTrigger("checkConsumableQty"));

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.EmployeeID)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Notes).HasMaxLength(100);

            entity.HasOne(d => d.Consumable).WithMany(p => p.ConsumableRecords)
                .HasForeignKey(d => d.ConsumableID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Consumabl__Consu__4BAC3F29");

            entity.HasOne(d => d.Employee).WithMany(p => p.ConsumableRecords)
                .HasForeignKey(d => d.EmployeeID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Consumabl__Emplo__4AB81AF0");
        });

        modelBuilder.Entity<Consumables>(entity =>
        {
            entity.HasKey(e => e.ConsumableID).HasName("PK__Consumab__50EE12D614A7091A");

            entity.Property(e => e.Cabinet).HasMaxLength(5);
            entity.Property(e => e.ConsumableName).HasMaxLength(60);
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
            entity.Property(e => e.PhotoType).HasMaxLength(50);
            entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);
            entity.Property(e => e.Shelf).HasMaxLength(5);

            entity.HasOne(d => d.Supplier).WithMany(p => p.Consumables)
                .HasForeignKey(d => d.SupplierID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Consumabl__Suppl__47DBAE45");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeID).HasName("PK__Employee__7AD04FF1F65A5000");

            entity.Property(e => e.EmployeeID)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(40);
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.password).HasMaxLength(12);
        });

        modelBuilder.Entity<Orders>(entity =>
        {
            entity.HasKey(e => e.OrderID).HasName("PK__Orders__C3905BAF0AA0C6E8");

            entity.ToTable(tb => tb.HasTrigger("orderQty"));

            entity.Property(e => e.DeliveryDate).HasColumnType("datetime");
            entity.Property(e => e.EmployeeID)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Notes).HasMaxLength(100);
            entity.Property(e => e.OrderDate).HasColumnType("datetime");

            entity.HasOne(d => d.Employee).WithMany(p => p.Orders)
                .HasForeignKey(d => d.EmployeeID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Orders__Employee__5EBF139D");
        });

        modelBuilder.Entity<SampleRecords>(entity =>
        {
            entity.HasKey(e => e.RecordID).HasName("PK__SampleRe__FBDF78C9D6325661");

            entity.ToTable(tb => tb.HasTrigger("checkSampleQty"));

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.EmployeeID)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Notes).HasMaxLength(100);

            entity.HasOne(d => d.Employee).WithMany(p => p.SampleRecords)
                .HasForeignKey(d => d.EmployeeID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__SampleRec__Emplo__3D5E1FD2");

            entity.HasOne(d => d.Sample).WithMany(p => p.SampleRecords)
                .HasForeignKey(d => d.SampleID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__SampleRec__Sampl__3E52440B");
        });

        modelBuilder.Entity<SampleType>(entity =>
        {
            entity.HasKey(e => e.TypeID).HasName("PK__SampleTy__516F03951D96D9ED");

            entity.Property(e => e.TypeName).HasMaxLength(10);
        });

        modelBuilder.Entity<Samples>(entity =>
        {
            entity.HasKey(e => e.SampleID).HasName("PK__Samples__8B99EC0ADEB9C60F");

            entity.Property(e => e.BoxName).HasMaxLength(40);
            entity.Property(e => e.Genotype).HasMaxLength(40);
            entity.Property(e => e.Refrigerator).HasMaxLength(4);
            entity.Property(e => e.SampleName).HasMaxLength(60);
            entity.Property(e => e.Species).HasMaxLength(40);

            entity.HasOne(d => d.SampleType).WithMany(p => p.Samples)
                .HasForeignKey(d => d.TypeID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Samples_SampleType");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierID).HasName("PK__Supplier__4BE66694DE95AD40");

            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.ContactName).HasMaxLength(20);
            entity.Property(e => e.ContactTel).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<LabAPI.Models.Cornonavirus> Cornonavirus { get; set; } = default!;
}
