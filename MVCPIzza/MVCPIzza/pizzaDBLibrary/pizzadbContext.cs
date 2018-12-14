using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MVCPIzza
{
    public partial class pizzadbContext : DbContext
    {
        public pizzadbContext()
        {
        }

        public pizzadbContext(DbContextOptions<pizzadbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<StoreIngredients> StoreIngredients { get; set; }
        public virtual DbSet<UserAddress> UserAddress { get; set; }
        public virtual DbSet<UserTbl> UserTbl { get; set; }

        // Unable to generate entity type for table 'dbo.Orders'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.PizzaIngredients'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=tcp:noyes1811.database.windows.net,1433;User Id=martin;Password=20Dollars!;Database=pizzadb;");
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
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PizzaIDOrderDetails");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Costs).HasColumnType("money");

                entity.Property(e => e.PizzaName)
                    .IsRequired()
                    .HasMaxLength(500);
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
