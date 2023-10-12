using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Commands;

public class IdentifiedCommandValidator : AbstractValidator<IdentifiedCommand<IRequest<bool>, bool>>
{
    public IdentifiedCommandValidator(ILogger<IdentifiedCommandValidator> logger)
    {
        RuleFor(command => command.Id).NotEmpty();

        logger.LogTrace("INSTANCE CREATED - {ClassName}", GetType().Name);
    }
}