using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace V9.Model
{
    public partial class ModelDB : DbContext
    {
        public ModelDB()
            : base("name=ModelDB")
        {
        }

        public virtual DbSet<Agent> Agent { get; set; }
        public virtual DbSet<AgentPriorityHistory> AgentPriorityHistory { get; set; }
        public virtual DbSet<AgentType> AgentType { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<MaterialCountHistory> MaterialCountHistory { get; set; }
        public virtual DbSet<MaterialType> MaterialType { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCostHistory> ProductCostHistory { get; set; }
        public virtual DbSet<ProductMaterial> ProductMaterial { get; set; }
        public virtual DbSet<ProductSale> ProductSale { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<Shop> Shop { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agent>()
                .Property(e => e.INN)
                .IsUnicode(false);

            modelBuilder.Entity<Agent>()
                .Property(e => e.KPP)
                .IsUnicode(false);

            modelBuilder.Entity<Agent>()
                .HasMany(e => e.AgentPriorityHistory)
                .WithRequired(e => e.Agent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Agent>()
                .HasMany(e => e.ProductSale)
                .WithRequired(e => e.Agent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Agent>()
                .HasMany(e => e.Shop)
                .WithRequired(e => e.Agent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AgentType>()
                .HasMany(e => e.Agent)
                .WithRequired(e => e.AgentType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Material>()
                .Property(e => e.Cost)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Material>()
                .HasOptional(e => e.MaterialCountHistory)
                .WithRequired(e => e.Material);

            modelBuilder.Entity<Material>()
                .HasMany(e => e.ProductMaterial)
                .WithRequired(e => e.Material)
                .HasForeignKey(e => e.MaterialID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Material>()
                .HasMany(e => e.Supplier)
                .WithMany(e => e.Material)
                .Map(m => m.ToTable("MaterialSupplier").MapLeftKey("MaterialID").MapRightKey("SupplierID"));

            modelBuilder.Entity<MaterialType>()
                .HasMany(e => e.Material)
                .WithRequired(e => e.MaterialType)
                .HasForeignKey(e => e.MaterialTypeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.MinCostForAgent)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Product>()
                .HasOptional(e => e.ProductCostHistory)
                .WithRequired(e => e.Product);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductMaterial)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.ProductID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasOptional(e => e.ProductSale)
                .WithRequired(e => e.Product);

            modelBuilder.Entity<ProductCostHistory>()
                .Property(e => e.CostValue)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ProductType>()
                .HasMany(e => e.Product)
                .WithOptional(e => e.ProductType)
                .HasForeignKey(e => e.ProductTypeID);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.INN)
                .IsUnicode(false);
        }
    }
}
