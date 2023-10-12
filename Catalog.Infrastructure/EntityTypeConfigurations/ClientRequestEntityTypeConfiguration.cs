using Catalog.Infrastructure.Context;
using Catalog.Infrastructure.Idempotency;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.EntityTypeConfigurations;

public class ClientRequestEntityTypeConfiguration : IEntityTypeConfiguration<ClientRequest>
{
    public void Configure(EntityTypeBuilder<ClientRequest> builder)
    {
        builder.ToTable("requests", CatalogContext.DEFAULT_SCHEMA);
        builder.HasKey(cr => cr.Id);
        builder.Property(cr => cr.Name).IsRequired();
        builder.Property(cr => cr.Time).IsRequired();
        
    }
}