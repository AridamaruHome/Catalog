using Core.Domain.Aggregates.ProductAggregate;
using Core.Infrastructure.Context;
using Core.Infrastructure.Idempotency;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infrastructure.EntityTypeConfigurations;

public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products", WarehouseContext.DEFAULT_SCHEMA);
        builder.HasKey(cr => cr.Id);
        builder.Property(cr => cr.Name).IsRequired();
    }
}