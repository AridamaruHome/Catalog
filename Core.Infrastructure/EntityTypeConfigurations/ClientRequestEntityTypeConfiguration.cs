using Core.Infrastructure.Context;
using Core.Infrastructure.Idempotency;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infrastructure.EntityTypeConfigurations;

public class ClientRequestEntityTypeConfiguration : IEntityTypeConfiguration<ClientRequest>
{
    public void Configure(EntityTypeBuilder<ClientRequest> builder)
    {
        builder.ToTable("requests", WarehouseContext.DEFAULT_SCHEMA);
        builder.HasKey(cr => cr.Id);
        builder.Property(cr => cr.Name).IsRequired();
        builder.Property(cr => cr.Time).IsRequired();
        
    }
}