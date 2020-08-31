using Accounting.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Infrastructure.Persistence.Configurations
{
    public class TotalAccountConfiguration : IEntityTypeConfiguration<TotalAccount>
    {
        public void Configure(EntityTypeBuilder<TotalAccount> builder)
        {
            var tablePrefix = "ACC_TOTAL_ACCOUNT_";
            builder.ToTable("ACC_TOTAL_ACCOUNTS");
            builder.HasKey(k => k.Id);
            builder.Property(t => t.Id).
                HasColumnName("ID");

            builder.HasOne(t => t.Customer)
                .WithMany(c => c.TotalAccounts)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(t => t.CustomerId);

            builder.HasOne(t => t.GeneralLedger)
                .WithMany(g => g.TotalAccounts)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(t => t.GeneralLeadgerId);

            builder.HasOne(t => t.MainAccount)
                .WithMany(m => m.TotalAccounts)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(t => t.MainAccountId);

            builder.Property(p => p.TotalAccountNameAr)
                .HasColumnName($"{tablePrefix}NAME_AR")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(p => p.TotalAccountNameEn)
                .HasColumnName($"{tablePrefix}NAME_EN")
                .HasMaxLength(250);

            builder.Property(p => p.TotalAccountIdByCustomer)
                .HasColumnName($"{tablePrefix}ID_BY_CUSTOMER")
                .HasMaxLength(250);

            builder.Property(p => p.IsClose)
                .HasColumnName($"{tablePrefix}IS_CLOSE");
                
            builder.Property(p => p.IsActive)
                .HasColumnName($"{tablePrefix}IS_ACTIVE")
                .HasDefaultValue(true);

            builder.Property(p => p.CustomerId)
                .HasColumnName($"{tablePrefix}CUSTOMER_ID");

            builder.Property(p => p.GeneralLeadgerId)
                .HasColumnName($"{tablePrefix}GL_ID");

            builder.Property(p => p.MainAccountId)
                .HasColumnName($"{tablePrefix}MAIN_ACCOUNT_ID");

            builder.SetAuditableFieldsNaming(tablePrefix);
        }
    }
}
