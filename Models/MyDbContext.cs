using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Ban_Caffee.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext() 
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerDetail> CustomerDetails { get; set; }

    public virtual DbSet<Good> Goods { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Inventoryrecord> Inventoryrecords { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<RecorDetail> RecorDetails { get; set; }

    public virtual DbSet<Recordtype> Recordtypes { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<SubCategory> SubCategories { get; set; }

    public virtual DbSet<Sysrole> Sysroles { get; set; }

    public virtual DbSet<Sysuser> Sysusers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Khang\\SQLEXPRESS;Database=StoreManageMent; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__category__19093A0BAE3FF85D");

            entity.Property(e => e.CategoryId).IsFixedLength();
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D8FA1EA3AD");

            entity.ToTable("Customer", "customers", tb => tb.HasTrigger("cancer_delete_Customer"));

            entity.Property(e => e.CustomerId).IsFixedLength();
            entity.Property(e => e.Status).HasDefaultValue("Hoạt động");
        });

        modelBuilder.Entity<CustomerDetail>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D8E25B3871");

            entity.ToTable("CustomerDetail", "customers", tb => tb.HasTrigger("trg_UpdateUsernameWhenEmailChanged"));

            entity.Property(e => e.CustomerId).IsFixedLength();
            entity.Property(e => e.Avatar).HasDefaultValue("/img/avatar-fb.jpg");
            entity.Property(e => e.IdNumber).IsFixedLength();
            entity.Property(e => e.PhoneNum).IsFixedLength();

            entity.HasOne(d => d.Customer).WithOne(p => p.CustomerDetail)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Detail_Customer");
        });

        modelBuilder.Entity<Good>(entity =>
        {
            entity.HasKey(e => e.GoodId).HasName("PK__goods__043AE53D9B29282F");

            entity.Property(e => e.GoodId).IsFixedLength();
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.InventoryId).HasName("PK__inventor__F5FDE6B3A98C667A");

            entity.ToTable("inventory", "management", tb => tb.HasTrigger("trg_cancer_delete_inventory"));

            entity.Property(e => e.Status).HasDefaultValue("Hoạt động");
            entity.Property(e => e.StoreId).IsFixedLength();

            entity.HasOne(d => d.Store).WithMany(p => p.Inventories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventory_Store");
        });

        modelBuilder.Entity<Inventoryrecord>(entity =>
        {
            entity.HasKey(e => e.RecordsId).HasName("PK__inventor__4C989987F5FEA7F1");

            entity.Property(e => e.RecordsId).IsFixedLength();

            entity.HasOne(d => d.Inventory).WithMany(p => p.Inventoryrecords)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CH_PNL");

            entity.HasOne(d => d.Type).WithMany(p => p.Inventoryrecords)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryReCord_Type");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__orders__C3905BCF9127666F");

            entity.ToTable("orders", tb =>
                {
                    tb.HasTrigger("cancer_delete_Order");
                    tb.HasTrigger("trg_UpdateCompleteDateOrder");
                });

            entity.Property(e => e.OrderId).IsFixedLength();
            entity.Property(e => e.CustomerId).IsFixedLength();
            entity.Property(e => e.Status).HasDefaultValue("Tiếp nhận");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders).HasConstraintName("FK_Customer_Order");

            entity.HasOne(d => d.SysUser).WithMany(p => p.Orders).HasConstraintName("FK_SysUser_Order");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId }).HasName("PK__order_de__08D097A3D46FFA07");

            entity.ToTable("order_detail", tb => tb.HasTrigger("trg_CancerUpdateOrder"));

            entity.Property(e => e.OrderId).IsFixedLength();
            entity.Property(e => e.ProductId).IsFixedLength();

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetail_Order");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetail_Product");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__products__B40CC6CDA6CD2842");

            entity.ToTable("products", tb => tb.HasTrigger("trg_cancer_delete_products"));

            entity.Property(e => e.ProductId).IsFixedLength();
            entity.Property(e => e.Status).HasDefaultValue("Kinh doanh");
            entity.Property(e => e.SubcategoryId).IsFixedLength();

            entity.HasOne(d => d.Subcategory).WithMany(p => p.Products)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_SubCategory");
        });

        modelBuilder.Entity<RecorDetail>(entity =>
        {
            entity.HasKey(e => new { e.GoodId, e.RecordsId }).HasName("PK__RecorDet__60F36CA5C26B5C7E");

            entity.ToTable("RecorDetail", "management", tb => tb.HasTrigger("trg_UpdateStock_General"));

            entity.Property(e => e.GoodId).IsFixedLength();
            entity.Property(e => e.RecordsId).IsFixedLength();

            entity.HasOne(d => d.Good).WithMany(p => p.RecorDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Record_Goods");

            entity.HasOne(d => d.Records).WithMany(p => p.RecorDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Detail_Record");
        });

        modelBuilder.Entity<Recordtype>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__recordty__516F03B55DE83DE1");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__staff__96D4AB170396DC9C");

            entity.ToTable("staff", "management", tb => tb.HasTrigger("CheckStaffAge"));

            entity.Property(e => e.StaffId).IsFixedLength();
            entity.Property(e => e.IdNumber).IsFixedLength();
            entity.Property(e => e.PhoneNum).IsFixedLength();
            entity.Property(e => e.RoleId).IsFixedLength();
            entity.Property(e => e.StoreId).IsFixedLength();

            entity.HasOne(d => d.Role).WithMany(p => p.Staff)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USER_ROLE");

            entity.HasOne(d => d.Store).WithMany(p => p.Staff).HasConstraintName("FK_Store_Staff");
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.Property(e => e.GoodId).IsFixedLength();
            entity.Property(e => e.Status).HasDefaultValue("Hết nguyên liệu");

            entity.HasOne(d => d.Good).WithMany(p => p.Stocks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Stock_Goods");

            entity.HasOne(d => d.Inventory).WithMany(p => p.Stocks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventory_Stock");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.StoreId).HasName("PK__store__3B82F0E19D24BADB");

            entity.ToTable("store", tb =>
                {
                    tb.HasTrigger("TrgCreateNewStore");
                    tb.HasTrigger("trg_cancer_delete_store");
                });

            entity.Property(e => e.StoreId).IsFixedLength();
            entity.Property(e => e.PhoneNum).IsFixedLength();
            entity.Property(e => e.StoreStatus).HasDefaultValue("Hoạt Động");
        });

        modelBuilder.Entity<SubCategory>(entity =>
        {
            entity.HasKey(e => e.SubCategoryId).HasName("PK__sub_cate__26BE5B19D5BD6F83");

            entity.Property(e => e.SubCategoryId).IsFixedLength();
            entity.Property(e => e.CategoryId).IsFixedLength();

            entity.HasOne(d => d.Category).WithMany(p => p.SubCategories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sub_Category");
        });

        modelBuilder.Entity<Sysrole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__sysrole__8AFACE1AB9D80AED");

            entity.Property(e => e.RoleId).IsFixedLength();
        });

        modelBuilder.Entity<Sysuser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__sysuser__1788CC4C76C982C6");

            entity.Property(e => e.Password).HasDefaultValue("$2a$10$YWJzGnAtUGlGGm2fjwK8/.arjFegAdxgGVVm7kCsrCtEDcR.XxRTm");
            entity.Property(e => e.RoleId).IsFixedLength();
            entity.Property(e => e.StaffId).IsFixedLength();
            entity.Property(e => e.StoreId).IsFixedLength();

            entity.HasOne(d => d.Role).WithMany(p => p.Sysusers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_RoleS");

            entity.HasOne(d => d.Staff).WithMany(p => p.Sysusers).HasConstraintName("FK_User_Staff");

            entity.HasOne(d => d.Store).WithMany(p => p.Sysusers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Store_SysUser");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
