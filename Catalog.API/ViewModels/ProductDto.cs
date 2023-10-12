namespace Catalog.Application.Queries;

public record ProductDto(Guid ProductId,
    string Name,
    string Description,
    string Category,
    string Barcode,
    string ImageUrl,
    DateTime CreationDate);