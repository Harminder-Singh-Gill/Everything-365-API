using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Everything_365.Data.Models;

namespace Everything_365.Data.DataContext
{
    public partial class EveryThing365DbContext : DbContext
    {
        public EveryThing365DbContext()
        {
        }

        public EveryThing365DbContext(DbContextOptions<EveryThing365DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; } = null!;
        public virtual DbSet<CustomerOrder> CustomerOrders { get; set; } = null!;
        public virtual DbSet<CustomerPayment> CustomerPayments { get; set; } = null!;
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; } = null!;
        public virtual DbSet<PaymentType> PaymentTypes { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public virtual DbSet<ProductItem> ProductItems { get; set; } = null!;
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; } = null!;
        public virtual DbSet<ShoppingCartItem> ShoppingCartItems { get; set; } = null!;
        public virtual DbSet<Store> Stores { get; set; } = null!;
        public virtual DbSet<StoreAddress> StoreAddresses { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=192.168.1.197; Database = EveryThing_365; User Id = Admin; Password =Admin123; Initial Catalog=EveryThing_365;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.HasIndex(e => e.CountryName, "UQ__country__F70188948424E57F")
                    .IsUnique();

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.CountryName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("country_name");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.HasIndex(e => e.EmailAddress, "UQ__customer__20C6DFF5D99D1062")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNumber, "UQ__customer__A1936A6B87CF47E3")
                    .IsUnique();

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email_address");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_at");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");
            });

            modelBuilder.Entity<CustomerAddress>(entity =>
            {
                entity.HasKey(e => e.AddressId)
                    .HasName("PK__customer__CAA247C87CC72A2B");

                entity.ToTable("customer_address");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("address_line1");

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("address_line2");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.IsDefault).HasColumnName("is_default");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("postal_code");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.CustomerAddresses)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__customer___count__3A81B327");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerAddresses)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__customer___custo__398D8EEE");
            });

            modelBuilder.Entity<CustomerOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__customer__46596229E7D703C7");

                entity.ToTable("customer_order");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("order_date");

                entity.Property(e => e.OrderStatusId).HasColumnName("order_status_id");

                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.Property(e => e.ProductItemId).HasColumnName("product_item_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.ShippingId).HasColumnName("shipping_id");

                entity.Property(e => e.TotalPrice).HasColumnName("total_price");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerOrders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__customer___custo__0C85DE4D");

                entity.HasOne(d => d.OrderStatus)
                    .WithMany(p => p.CustomerOrders)
                    .HasForeignKey(d => d.OrderStatusId)
                    .HasConstraintName("FK__customer___order__10566F31");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.CustomerOrders)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK__customer___payme__0E6E26BF");

                entity.HasOne(d => d.ProductItem)
                    .WithMany(p => p.CustomerOrders)
                    .HasForeignKey(d => d.ProductItemId)
                    .HasConstraintName("FK__customer___produ__0D7A0286");

                entity.HasOne(d => d.Shipping)
                    .WithMany(p => p.CustomerOrders)
                    .HasForeignKey(d => d.ShippingId)
                    .HasConstraintName("FK__customer___shipp__0F624AF8");
            });

            modelBuilder.Entity<CustomerPayment>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("PK__customer__ED1FC9EAD6427F02");

                entity.ToTable("customer_payment");

                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("account_number");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnType("date")
                    .HasColumnName("expiry_date");

                entity.Property(e => e.IsDefault).HasColumnName("is_default");

                entity.Property(e => e.PaymentProvider)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("payment_provider");

                entity.Property(e => e.PaymentTypeId).HasColumnName("payment_type_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerPayments)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__customer___custo__7E37BEF6");

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.CustomerPayments)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .HasConstraintName("FK__customer___payme__7F2BE32F");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK__order_st__3683B53181B42BD3");

                entity.ToTable("order_status");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.OrderValue)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("order_value");
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.ToTable("payment_type");

                entity.Property(e => e.PaymentTypeId).HasColumnName("payment_type_id");

                entity.Property(e => e.PaymentValue)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("payment_value");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.HasIndex(e => e.ProductName, "UQ__product__2B5A6A5FA566C710")
                    .IsUnique();

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("product_description");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("product_name");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__product__categor__60A75C0F");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__product___D54EE9B407EEBA8C");

                entity.ToTable("product_category");

                entity.HasIndex(e => e.CategoryName, "UQ__product___5189E25533FCA2F2")
                    .IsUnique();

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("category_name");

                entity.Property(e => e.ParentCategoryId).HasColumnName("parent_category_id");

                entity.HasOne(d => d.ParentCategory)
                    .WithMany(p => p.InverseParentCategory)
                    .HasForeignKey(d => d.ParentCategoryId)
                    .HasConstraintName("FK__product_c__paren__59FA5E80");
            });

            modelBuilder.Entity<ProductItem>(entity =>
            {
                entity.ToTable("product_item");

                entity.Property(e => e.ProductItemId).HasColumnName("product_item_id");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.QtyInStock).HasColumnName("qty_in_stock");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__product_i__produ__6754599E");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.ProductItems)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__product_i__store__68487DD7");
            });

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.HasKey(e => e.CartId)
                    .HasName("PK__shopping__2EF52A2707556D3C");

                entity.ToTable("shopping_cart");

                entity.Property(e => e.CartId).HasColumnName("cart_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ShoppingCarts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__shopping___custo__6C190EBB");
            });

            modelBuilder.Entity<ShoppingCartItem>(entity =>
            {
                entity.HasKey(e => e.CartItemId)
                    .HasName("PK__shopping__5D9A6C6E4A51217A");

                entity.ToTable("shopping_cart_item");

                entity.Property(e => e.CartItemId).HasColumnName("cart_item_id");

                entity.Property(e => e.CartId).HasColumnName("cart_id");

                entity.Property(e => e.ProductItemId).HasColumnName("product_item_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.ShoppingCartItems)
                    .HasForeignKey(d => d.CartId)
                    .HasConstraintName("FK__shopping___cart___71D1E811");

                entity.HasOne(d => d.ProductItem)
                    .WithMany(p => p.ShoppingCartItems)
                    .HasForeignKey(d => d.ProductItemId)
                    .HasConstraintName("FK__shopping___produ__72C60C4A");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("store");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.Property(e => e.StoreName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("store_name");

                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK__store__supplier___49C3F6B7");
            });

            modelBuilder.Entity<StoreAddress>(entity =>
            {
                entity.HasKey(e => e.AddressId)
                    .HasName("PK__store_ad__CAA247C8EFC13E65");

                entity.ToTable("store_address");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("address_line1");

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("address_line2");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.IsDefault).HasColumnName("is_default");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("postal_code");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.StoreAddresses)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__store_add__count__5441852A");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StoreAddresses)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__store_add__store__534D60F1");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("supplier");

                entity.HasIndex(e => e.EmailAddress, "UQ__supplier__20C6DFF55A47ED0F")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNumber, "UQ__supplier__A1936A6B5DD8893C")
                    .IsUnique();

                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email_address");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_at");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
