using Accounting.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Infrastructure.Persistence.Configurations
{
    public class MainAccountConfiguration : IEntityTypeConfiguration<MainAccount>
    {
        public void Configure(EntityTypeBuilder<MainAccount> builder)
        {
            var tablePrefix = "ACC_MAIN_ACCOUNT_";
            builder.ToTable("ACC_MAIN_ACCOUNTS");
            builder.HasKey(k => k.Id);
            builder.Property(t => t.Id).
                HasColumnName("ID");

            builder.HasOne(m => m.Customer)
                .WithMany(c => c.MainAccounts)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(m => m.CustomerId);

            builder.HasOne(m => m.GeneralLedger)
                .WithMany(g => g.MainAccounts)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(m => m.GeneralLeadgerId);

            builder.Property(p => p.MainAccountNameAr)
                .HasColumnName($"{tablePrefix}NAME_AR")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(p => p.MainAccountNameEn)
                .HasColumnName($"{tablePrefix}NAME_EN")
                .HasMaxLength(250);

            builder.Property(p => p.MainAccountIdByCustomer)
                .HasColumnName($"{tablePrefix}ID_BY_CUSTOMER")
                .HasMaxLength(250);

            builder.Property(p => p.IsActive)
                .HasColumnName($"{tablePrefix}IS_ACTIVE")
                .HasDefaultValue(true);

            builder.Property(p => p.CustomerId)
                .HasColumnName($"{tablePrefix}CUSTOMER_ID");

            builder.Property(p => p.GeneralLeadgerId)
                .HasColumnName($"{tablePrefix}GL_ID");

            builder.SetAuditableFieldsNaming(tablePrefix);
        }
    }
}
