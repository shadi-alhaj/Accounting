using Accounting.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Accounting.Infrastructure.Persistence.Configurations
{
    public static class SetAuditableFieldsNamingHelper
    {
        public static void SetAuditableFieldsNaming<Entity>(this EntityTypeBuilder<Entity> builder, string tablePrefix)
        where Entity : AuditableEntity
        {
            builder.Property(e => e.Created)
                .HasColumnName($"{tablePrefix}CRT_DATE");
            builder.Property(e => e.LastModified)
                .HasColumnName($"{tablePrefix}UPD_DATE");
            builder.Property(e => e.CreatedBy)
                .HasColumnName($"{tablePrefix}CRT_BY_USR_ID");
            builder.Property(e => e.LastModifiedBy)
                .HasColumnName($"{tablePrefix}UPD_BY_USR_ID");
        }
    }
}
