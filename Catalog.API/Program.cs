using Catalog.API.Behaviour;
using Catalog.API.Configurations;
using Catalog.Application.Commands;
using Catalog.Application.Commands.CreateProduct;
using Catalog.Application.Queries;
using Catalog.Domain.Aggregates.ProductAggregate;
using Catalog.Infrastructure.Context;
using Catalog.Infrastructure.Idempotency;
using Catalog.Infrastructure.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

IWebHostEnvironment env = builder.Environment;

IConfiguration configuration = builder.Configuration;

builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();

builder.Services.AddCustomServices(configuration)
    .AddCustomAuthentication(configuration)
    .AddCustomDbContext(configuration)
    .AddCustomHttpContext(configuration)
    .AddCustomSwagger(configuration);

builder.Services.AddRouting(options => { options.LowercaseUrls = true; });
builder.Services.AddHealthChecks();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining(typeof(Program));
    cfg.RegisterServicesFromAssemblyContaining(typeof(CreateProductCommandHandler));
    cfg.RegisterServicesFromAssemblyContaining(typeof(IdentifiedCommand<,>));

    cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
    cfg.AddOpenBehavior(typeof(ValidatorBehavior<,>));
    cfg.AddOpenBehavior(typeof(TransactionBehavior<,>));
});

builder.Services.AddSingleton<IValidator<CreateProductCommand>, CreateProductCommandValidator>();
builder.Services.AddSingleton<IValidator<IdentifiedCommand<IRequest<bool>, bool>>, IdentifiedCommandValidator>();

builder.Services.AddScoped<IRequestManager, RequestManager>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IProductQueries, ProductQueries>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Migrate Context
app!.Services.CreateScope().ServiceProvider.GetService<CatalogContext>()!.Database.Migrate();

app.UseHttpsRedirection();
// app.UseAuthentication();
// app.UseAuthorization();

app.MapControllers();

app.Run();