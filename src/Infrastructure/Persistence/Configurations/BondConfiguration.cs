using Accounting.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Accounting.Infrastructure.Persistence.Configurations
{
    public class BondConfiguration : IEntityTypeConfiguration<Bond>
    {
        public void Configure(EntityTypeBuilder<Bond> builder)
        {
            var tablePrefix = "ACC_BOND_";
            builder.ToTable("ACC_BONDS");
            builder.HasKey(k => k.Id);
            builder.Property(t => t.Id).
                HasColumnName("ID");

            builder.HasOne(b => b.Customer)
                .WithMany(c => c.Bonds)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.BondUserId)
                .HasColumnName($"{tablePrefix}USER_ID");

            builder.Property(p => p.IntialSNo)
                .HasColumnName($"{tablePrefix}INTIAL_SNO");

            builder.Property(p => p.BondNameAr)
                .HasColumnName($"{tablePrefix}NAME_AR")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(p => p.BondNameEn)
                .HasColumnName($"{tablePrefix}NAME_EN")
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
