using Accounting.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Infrastructure.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            var tablePrefix = "ACC_CUSTOMER_";
            builder.ToTable("ACC_CUSTOMERS");
            builder.HasKey(k => k.Id);
            builder.Property(t => t.Id).
                HasColumnName("ID");

            builder.Property(p => p.CustomerId)
                .HasColumnName($"{tablePrefix}ID")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.CustomerNameAr)
                .HasColumnName($"{tablePrefix}NAME_AR")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(p => p.CustomerNameEn)
                .HasColumnName($"{tablePrefix}NAME_EN")
                .HasMaxLength(250);

            builder.Property(p => p.TaxNo)
                .HasColumnName($"{tablePrefix}TAX_NO")
                .HasMaxLength(20);


            builder.Property(p => p.FaxNo)
                .HasColumnName($"{tablePrefix}FAX_NO")
                .HasMaxLength(20);


            builder.Property(p => p.PhoneNo)
                .HasColumnName($"{tablePrefix}PHONE_NO")
                .HasMaxLength(20);


            builder.Property(p => p.MobileNo1)
                .HasColumnName($"{tablePrefix}MOBILE_NO1")
                .HasMaxLength(14);


            builder.Property(p => p.MobileNo2)
                .HasColumnName($"{tablePrefix}MOBILE_NO2")
                .HasMaxLength(14);


            builder.Property(p => p.Country)
                .HasColumnName($"{tablePrefix}COUNTRY")
                .HasMaxLength(100);


            builder.Property(p => p.City)
                .HasColumnName($"{tablePrefix}CITY")
                .HasMaxLength(100);


            builder.Property(p => p.Address)
                .HasColumnName($"{tablePrefix}ADDRESS")
                .HasMaxLength(250);


            builder.Property(p => p.Email)
                .HasColumnName($"{tablePrefix}EMAIL")
                .HasMaxLength(100);

            builder.Property(p => p.IsActive)
                .HasColumnName($"{tablePrefix}IS_ACTIVE")
                .HasDefaultValue(true);

            builder.SetAuditableFieldsNaming(tablePrefix);


            builder.HasData(
                new Customer
                {
                    Id = Guid.NewGuid(),
                    CustomerNameAr = "مكتب المدير",
                    CustomerNameEn = "Almodeer Office",
                    MobileNo1 = "0795980824",
                    Country = "Jordan",
                    City = "Amman",
                    Address = "Macca St.",
                    TaxNo = "123456"
                }
            );
        }
    }
}
