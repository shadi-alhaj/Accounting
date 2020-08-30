using Accounting.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Accounting.Infrastructure.Persistence.Configurations
{
    public class GeneralLedgerConfiguration : IEntityTypeConfiguration<GeneralLedger>
    {
        public void Configure(EntityTypeBuilder<GeneralLedger> builder)
        {
            var tablePrefix = "ACC_GL_";
            builder.ToTable("ACC_GENERAL_LEDGERS");
            builder.HasKey(k => k.Id);
            builder.Property(t => t.Id).
                HasColumnName("ID");

            builder.HasOne(g => g.Customer)
                .WithMany(c => c.GeneralLedgers)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.GLNameAr)
                .HasColumnName($"{tablePrefix}NAME_AR")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(p => p.GlNameEn)
                .HasColumnName($"{tablePrefix}NAME_EN")
                .HasMaxLength(250);

            builder.Property(p => p.GlIdByCustomer)
                .HasColumnName($"{tablePrefix}ID_BY_CUSTOMER")
                .HasMaxLength(250);

            builder.Property(p => p.IsActive)
                .HasColumnName($"{tablePrefix}IS_ACTIVE")
                .HasDefaultValue(true);

            builder.Property(p => p.CustomerId)
                .HasColumnName($"{tablePrefix}CUSTOMER_ID");

            builder.SetAuditableFieldsNaming(tablePrefix);
        }
    }
}
