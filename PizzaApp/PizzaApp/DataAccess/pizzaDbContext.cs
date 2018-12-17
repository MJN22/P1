using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaApp.DataAccess
{
    public partial class pizzaDbContext : DbContext
    {
        public pizzaDbContext()
        {
        }

        public pizzaDbContext(DbContextOptions<pizzaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaIngredients> PizzaIngredients { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<StoreIngredients> StoreIngredients { get; set; }
        public virtual DbSet<UserAddress> UserAddress { get; set; }
        public virtual DbSet<UserTbl> UserTbl { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=tcp:noyes1811.database.windows.net,1433;User Id=martin;Password=20Dollars!;Database=pizzaDb;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__OrderDet__C3905BAFAA3BBD4B");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PizzaId).HasColumnName("PizzaID");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.OrderDetailsIdNavigation)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PizzaIDOrderDetails");

                entity.HasOne(d => d.QuantityNavigation)
                    .WithMany(p => p.OrderDetailsQuantityNavigation)
                    .HasForeignKey(d => d.Quantity)
                    .HasConstraintName("FK_Quantity");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Orders__59B356445807902B");

                entity.Property(e => e.OrderId).HasColumnName("_orderId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.StoreAddressId).HasColumnName("StoreAddressID");

                entity.Property(e => e.UserOrderAddressId).HasColumnName("UserOrderAddressID");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID");

                entity.HasOne(d => d.StoreAddress)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StoreAddressID");

                entity.HasOne(d => d.UserOrderAddress)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserOrderAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserOrderAddressID");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Costs).HasColumnType("money");

                entity.Property(e => e.PizzaName)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<PizzaIngredients>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IngredientName)
                    .IsRequired()
                    .HasMaxLength(108);

                entity.Property(e => e.PizzaId).HasColumnName("PizzaID");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.PizzaIngredients)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_PizzaID");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.StoreAddressId)
                    .HasName("PK__Store__05A960CE8989E40B");

                entity.Property(e => e.StoreAddressId).HasColumnName("StoreAddressID");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CountryAbrev)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.ProvidenceState)
                    .IsRequired()
                    .HasMaxLength(108);

                entity.Property(e => e.StoreAddress)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StoreIngredients>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.StoreIngredientsAddressId).HasColumnName("StoreIngredientsAddressID");

                entity.HasOne(d => d.StoreIngredientsAddress)
                    .WithMany(p => p.StoreIngredients)
                    .HasForeignKey(d => d.StoreIngredientsAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StoreIngredientsAddressID");
            });

            modelBuilder.Entity<UserAddress>(entity =>
            {
                entity.Property(e => e.UserAddressId)
                    .HasColumnName("UserAddressID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CountryAbrev)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.ProvidenceState)
                    .IsRequired()
                    .HasMaxLength(108);

                entity.HasOne(d => d.UserAddressNavigation)
                    .WithOne(p => p.UserAddress)
                    .HasForeignKey<UserAddress>(d => d.UserAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAddressID");
            });

            modelBuilder.Entity<UserTbl>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserTBL__1788CCAC72AF4264");

                entity.ToTable("UserTBL");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(108);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(108);
            });
        }
    }
}
