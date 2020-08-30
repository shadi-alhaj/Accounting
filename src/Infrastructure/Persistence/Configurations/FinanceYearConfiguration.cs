using Accounting.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Accounting.Infrastructure.Persistence.Configurations
{
    public class FinanceYearConfiguration : IEntityTypeConfiguration<FinanceYear>
    {
        public void Configure(EntityTypeBuilder<FinanceYear> builder)
        {
            var tablePrefix = "ACC_FINANCE_YEAR_";
            builder.ToTable("ACC_FINANCE_YEARS");
            builder.HasKey(k => k.Id);
            builder.Property(t => t.Id).
                HasColumnName("ID");

            builder.HasOne(f => f.Customer)
                .WithMany(c => c.FinanceYears)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.Year)
                .HasColumnName($"{tablePrefix}YEAR")
                .IsRequired();

            builder.Property(p => p.IsActive)
                .HasColumnName($"{tablePrefix}IS_ACTIVE")
                .HasDefaultValue(true);

            builder.Property(p => p.CustomerId)
                .HasColumnName($"{tablePrefix}CUSTOMER_ID");

            builder.SetAuditableFieldsNaming(tablePrefix);

        }
    }
}
