using Catalog.Infrastructure.Idempotency;
using Catalog.Shared.Extensions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Commands;

public abstract class IdentifiedCommandHandler<T, R> : IRequestHandler<IdentifiedCommand<T, R>, R> where T : IRequest<R>
{
    private readonly IMediator _mediator;
    private readonly IRequestManager _requestManager;
    private readonly ILogger<IdentifiedCommandHandler<T, R>> _logger;

    public IdentifiedCommandHandler(IMediator mediator,
        IRequestManager requestManager,
        ILogger<IdentifiedCommandHandler<T, R>> logger)
    {
        ArgumentNullException.ThrowIfNull(logger);
        _mediator = mediator;
        _requestManager = requestManager;
        _logger = logger;
    }

    protected abstract R CreatedResultForDuplicateRequest();

    public async Task<R> Handle(IdentifiedCommand<T, R> request, CancellationToken cancellationToken)
    {
        var alreadyExists = await _requestManager.Exist(request.Id);
        if (alreadyExists)
        {
            return CreatedResultForDuplicateRequest();
        }

        await _requestManager.CreateRequestForCommand<T>(request.Id);
        try
        {
            var command = request.Command;
            var commandName = command.GetGenericTypeName();
            var idProperty = string.Empty;
            var commandId = string.Empty;

            switch (command)
            {
                default:
                    idProperty = "Id?";
                    commandId = "n/a";
                    break;
            }

            _logger.LogInformation(
                "Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                commandName,
                idProperty,
                commandId,
                command);

            var result = await _mediator.Send(command, cancellationToken);

            _logger.LogInformation(
                "Command result: {@Result} - {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                result,
                commandName,
                idProperty,
                commandId,
                command);

            return result;
        }
        catch
        {
            return default;
        }
    }
}