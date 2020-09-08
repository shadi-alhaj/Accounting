using Accounting.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Infrastructure.Persistence.Configurations
{
    public class DailyTransactionConfiguration : IEntityTypeConfiguration<DailyTransaction>
    {
        public void Configure(EntityTypeBuilder<DailyTransaction> builder)
        {
            var tablePrefix = "ACC_DAILY_TRANSACTION_";
            builder.ToTable("ACC_DAILY_TRANSACTIONS");
            builder.HasKey(k => k.Id);
            builder.Property(d => d.Id).
                HasColumnName("ID");

            builder.HasOne(d => d.Customer)
                .WithMany(c => c.DailyTransactions)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(d => d.CustomerId);

            builder.HasOne(d => d.Bond)
                .WithMany(b => b.DailyTransactions)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(d => d.BondId);

            builder.HasOne(d => d.GeneralLedger)
                .WithMany(g => g.DailyTransactions)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(d => d.GeneralLedgerId);

            builder.HasOne(d => d.MainAccount)
                .WithMany(m => m.DailyTransactions)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(d => d.MainAccountId);

            builder.HasOne(d => d.TotalAccount)
                .WithMany(t => t.DailyTransactions)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(d => d.TotalAccountId);

            builder.HasOne(d => d.DetailAccount)
                .WithMany(d => d.DailyTransactions)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(d => d.DetailAccountId);

            builder.Property(p => p.DailyTransactionIdByCustomer)
                .HasColumnName($"{tablePrefix}ID_BY_CUSTOMER");

            builder.Property(p => p.DailyTransactionBondSNo)
                .HasColumnName($"{tablePrefix}BOND_SNO")
                .IsRequired();

            builder.Property(p => p.DailyTransactionDate)
                .HasColumnName($"{tablePrefix}DATE")
                .IsRequired();

            builder.Property(p => p.DailyTransactionMonth)
                .HasColumnName($"{tablePrefix}MONTH")
                .IsRequired();

            builder.Property(p => p.DailyTransactionYear)
                .HasColumnName($"{tablePrefix}YEAR")
                .IsRequired();

            builder.Property(p => p.DailyTransactionDebitAmount)
                .HasColumnName($"{tablePrefix}DEBIT_AMOUNT")
                .HasColumnType("decimal(18,3)");

            builder.Property(p => p.DailyTransactionCreditAmount)
             .HasColumnName($"{tablePrefix}CREDIT_AMOUNT")
             .HasColumnType("decimal(18,3)");

            builder.Property(p => p.DailyTransactionDescription)
                .HasColumnName($"{tablePrefix}DESCRIPTION")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(p => p.IsActive)
                .HasColumnName($"{tablePrefix}IS_ACTIVE")
                .HasDefaultValue(true);

            builder.Property(p => p.CustomerId)
                .HasColumnName($"{tablePrefix}CUSTOMER_ID");

            builder.Property(p => p.BondId)
                .HasColumnName($"{tablePrefix}BOND_ID");

            builder.Property(p => p.GeneralLedgerId)
                .HasColumnName($"{tablePrefix}GL_ID");

            builder.Property(p => p.MainAccountId)
                .HasColumnName($"{tablePrefix}MAIN_ACCOUNT_ID");

            builder.Property(p => p.TotalAccountId)
               .HasColumnName($"{tablePrefix}TOTAL_ACCOUNT_ID");

            builder.Property(p => p.DetailAccountId)
               .HasColumnName($"{tablePrefix}DETAIL_ACCOUNT_ID");

            builder.SetAuditableFieldsNaming(tablePrefix);
        }
    }
}
