using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace api.Models
{
    public partial class PRCO304_wbutlerContext : DbContext
    {
        public PRCO304_wbutlerContext()
        {
        }

        public PRCO304_wbutlerContext(DbContextOptions<PRCO304_wbutlerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Shops> Shops { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=socem1.uopnet.plymouth.ac.uk;Database=PRCO304_wbutler;User Id=WButler; Password=SOFT549!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("customers_customer_id_pk");

                entity.ToTable("CUSTOMERS");

                entity.HasIndex(e => e.EmailAddress)
                    .HasName("customers_email_address_un")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("customers_username_un")
                    .IsUnique();

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.AddressLineOne)
                    .IsRequired()
                    .HasColumnName("address_line_one")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLineTwo)
                    .HasColumnName("address_line_two")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerHashedPassword)
                    .IsRequired()
                    .HasColumnName("customer_hashed_password")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("date_of_birth")
                    .HasColumnType("date");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasColumnName("email_address")
                    .HasMaxLength(62)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasColumnName("password_salt")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Postcode)
                    .IsRequired()
                    .HasColumnName("postcode")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("employees_employee_id_pk");

                entity.ToTable("EMPLOYEES");

                entity.HasIndex(e => e.EmployeeEmailAddress)
                    .HasName("employees_employee_email_address_un")
                    .IsUnique();

                entity.HasIndex(e => e.EmployeeUsername)
                    .HasName("employees_employee_username_un")
                    .IsUnique();

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.EmployeeAccountNo)
                    .IsRequired()
                    .HasColumnName("employee_account_no")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeAddressLineOne)
                    .IsRequired()
                    .HasColumnName("employee_address_line_one")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeAddressLineTwo)
                    .HasColumnName("employee_address_line_two")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeDateOfBirth)
                    .HasColumnName("employee_date_of_birth")
                    .HasColumnType("date");

                entity.Property(e => e.EmployeeEmailAddress)
                    .IsRequired()
                    .HasColumnName("employee_email_address")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeFirstName)
                    .IsRequired()
                    .HasColumnName("employee_first_name")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeHashedPassword)
                    .IsRequired()
                    .HasColumnName("employee_hashed_password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeLastName)
                    .IsRequired()
                    .HasColumnName("employee_last_name")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeePasswordSalt)
                    .IsRequired()
                    .HasColumnName("employee_password_salt")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeePostcode)
                    .IsRequired()
                    .HasColumnName("employee_postcode")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeShopId).HasColumnName("employee_shop_id");

                entity.Property(e => e.EmployeeSortCode)
                    .IsRequired()
                    .HasColumnName("employee_sort_code")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeUsername)
                    .IsRequired()
                    .HasColumnName("employee_username")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.JobRole)
                    .IsRequired()
                    .HasColumnName("job_role")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.EmployeeShop)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmployeeShopId)
                    .HasConstraintName("employees_employee_shop_id_fk");
            });

            modelBuilder.Entity<Shops>(entity =>
            {
                entity.HasKey(e => e.ShopId)
                    .HasName("shops_shop_id_pk");

                entity.ToTable("SHOPS");

                entity.Property(e => e.ShopId)
                    .HasColumnName("shop_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ShopAddressLineOne)
                    .IsRequired()
                    .HasColumnName("shop_address_line_one")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShopAddressLineTwo)
                    .HasColumnName("shop_address_line_two")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShopName)
                    .HasColumnName("shop_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShopPostcode)
                    .IsRequired()
                    .HasColumnName("shop_postcode")
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.HasSequence<int>("customer_id_seq");

            modelBuilder.HasSequence<int>("employee_id_seq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
