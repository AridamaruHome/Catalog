using FluentValidation;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Commands.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator(ILogger<UpdateProductCommandValidator> logger)
    {
        RuleFor(command => command.ProductId).NotEmpty();
        RuleFor(command => command.Name).NotEmpty();
        RuleFor(command => command.Description).NotEmpty();
        RuleFor(command => command.Category).NotEmpty();
        RuleFor(command => command.Barcode).NotEmpty();
        RuleFor(command => command.ImageUrl).NotEmpty();
    }
}