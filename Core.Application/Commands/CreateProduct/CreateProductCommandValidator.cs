using FluentValidation;
using Microsoft.Extensions.Logging;

namespace Core.Application.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator(ILogger<CreateProductCommandValidator> logger)
    {
        RuleFor(command => command.Name).NotEmpty();
        RuleFor(command => command.Description).NotEmpty();
        RuleFor(command => command.Category).NotEmpty();
        RuleFor(command => command.Barcode).NotEmpty();
        RuleFor(command => command.ImageUrl).NotEmpty();
    }
}