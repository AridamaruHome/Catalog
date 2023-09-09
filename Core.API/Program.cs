using Core.API.Behaviour;
using Core.API.Configurations;
using Core.Infrastructure.Context;
using Core.Infrastructure.Idempotency;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

IWebHostEnvironment env = builder.Environment;

IConfiguration configuration = builder.Configuration;

builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCustomServices(configuration)
    .AddCustomAuthentication(configuration)
    .AddCustomDbContext(configuration)
    .AddCustomHttpContext(configuration)
    .AddCustomSwagger(configuration);

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddRouting(options => { options.LowercaseUrls = true; });
builder.Services.AddHealthChecks();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining(typeof(Program));

    cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
    cfg.AddOpenBehavior(typeof(ValidatorBehavior<,>));
});

builder.Services.AddScoped<IRequestManager, RequestManager>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Migrate Context
app!.Services.CreateScope().ServiceProvider.GetService<WarehouseContext>()!.Database.Migrate();

app.UseHttpsRedirection();
// app.UseAuthentication();
// app.UseAuthorization();

app.MapControllers();

app.Run();