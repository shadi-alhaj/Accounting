using Accounting.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Infrastructure.Persistence.Configurations
{
    public class DetailAccountConfiguration : IEntityTypeConfiguration<DetailAccount>
    {
        public void Configure(EntityTypeBuilder<DetailAccount> builder)
        {
            var tablePrefix = "ACC_DETAIL_ACCOUNT_";
            builder.ToTable("ACC_DETAIL_ACCOUNTS");
            builder.HasKey(k => k.Id);
            builder.Property(d => d.Id).
                HasColumnName("ID");

            builder.HasOne(d => d.Customer)
                .WithMany(c => c.DetailAccounts)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(d => d.CustomerId);

            builder.HasOne(d => d.GeneralLedger)
                .WithMany(g => g.DetailAccounts)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(d => d.GeneralLeadgerId);

            builder.HasOne(d => d.MainAccount)
                .WithMany(m => m.DetailAccounts)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(d => d.MainAccountId);

            builder.HasOne(d => d.TotalAccount)
                .WithMany(t => t.DetailAccounts)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(d => d.TotalAccountId);

            builder.Property(p => p.DetailAccountNameAr)
                .HasColumnName($"{tablePrefix}NAME_AR")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(p => p.DetailAccountNameEn)
                .HasColumnName($"{tablePrefix}NAME_EN")
                .HasMaxLength(250);

            builder.Property(p => p.DetailAccountIdByCustomer)
                .HasColumnName($"{tablePrefix}ID_BY_CUSTOMER")
                .HasMaxLength(250);       

            builder.Property(p => p.IsActive)
                .HasColumnName($"{tablePrefix}IS_ACTIVE")
                .HasDefaultValue(true);

            builder.Property(p => p.CustomerId)
                .HasColumnName($"{tablePrefix}CUSTOMER_ID");

            builder.Property(p => p.GeneralLeadgerId)
                .HasColumnName($"{tablePrefix}GL_ID");

            builder.Property(p => p.MainAccountId)
                .HasColumnName($"{tablePrefix}MAIN_ACCOUNT_ID");

            builder.Property(p => p.TotalAccountId)
               .HasColumnName($"{tablePrefix}TOTAL_ACCOUNT_ID");

            builder.SetAuditableFieldsNaming(tablePrefix);
        }
    }    
}
