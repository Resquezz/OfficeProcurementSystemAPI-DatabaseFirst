using System;
using System.Collections.Generic;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using OfficeProcurementSystem.Domain.Models;

namespace OfficeProcurementSystem.Infrastructure.Data;

public partial class OfficeProcurementDbContext : DbContext
{
    public OfficeProcurementDbContext()
    {
    }

    public OfficeProcurementDbContext(DbContextOptions<OfficeProcurementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AnomalyExpense> AnomalyExpenses { get; set; }

    public virtual DbSet<Budget> Budgets { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<ExpenseReport> ExpenseReports { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost;Database=KPZ_DB_DBFIRST;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnomalyExpense>(entity =>
        {
            entity.HasIndex(e => e.PurchaseId, "IX_AnomalyExpenses_PurchaseId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Purchase).WithMany(p => p.AnomalyExpenses).HasForeignKey(d => d.PurchaseId);
        });

        modelBuilder.Entity<Budget>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AvailableAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.GeneralAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<ExpenseReport>(entity =>
        {
            entity.HasIndex(e => e.BudgetId, "IX_ExpenseReports_BudgetId");

            entity.HasIndex(e => e.UserId, "IX_ExpenseReports_UserId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.TotalExpenses).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Budget).WithMany(p => p.ExpenseReports)
                .HasForeignKey(d => d.BudgetId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.User).WithMany(p => p.ExpenseReports).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasIndex(e => e.CategoryId, "IX_Purchases_CategoryId");

            entity.HasIndex(e => e.UserId, "IX_Purchases_UserId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.RequestedAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.Category).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.User).WithMany(p => p.Purchases).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasIndex(e => e.CategoryId, "IX_Suppliers_CategoryId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(200);

            entity.HasOne(d => d.Category).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.Email, "IX_Users_Email").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
