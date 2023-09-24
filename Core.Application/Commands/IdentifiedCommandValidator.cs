using Core.Application.Commands.CreateProduct;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace Core.Application.Commands;

public class IdentifiedCommandValidator : AbstractValidator<IdentifiedCommand<CreateProductCommand, bool>>
{
    public IdentifiedCommandValidator(ILogger<IdentifiedCommandValidator> logger)
    {
        RuleFor(command => command.Id).NotEmpty();

        logger.LogTrace("INSTANCE CREATED - {ClassName}", GetType().Name);
    }
}