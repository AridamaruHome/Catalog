using Catalog.Domain.Aggregates.ProductAggregate;
using Catalog.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.EntityTypeConfigurations;

public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products", CatalogContext.DEFAULT_SCHEMA);
        builder.HasKey(cr => cr.Id);
        builder.HasIndex(cr => cr.ProductId);
        builder.Property(cr => cr.Name).IsRequired();
    }
}