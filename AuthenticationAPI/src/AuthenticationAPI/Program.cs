using AuthenticationAPI.Services.Interfaces;
using AuthenticationAPI.Services;
using Microsoft.OpenApi.Models;
using AuthenticationAPI.DataAccess;
using Microsoft.EntityFrameworkCore;
using APIHelperLIB.Services;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
    configuration.MinimumLevel.Information();
    configuration.MinimumLevel.Override("Microsoft", LogEventLevel.Warning);
    configuration.MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning);
    configuration.Enrich.FromLogContext();
    configuration.Enrich.WithCorrelationIdHeader("mb-correlation-id");


}).ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.SetMinimumLevel(LogLevel.Information);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Authentication API",
        Description = "An ASP.NET Core Web API for managing ToDo items",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        }
    });
});

builder.Services.AddHealthChecks();

builder.Services.AddDbContext<CustomerAuthenContext>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("DemoContext")));

builder.Services.AddScoped<IHttpConnectService, HttpConnectService>();

builder.Services.AddScoped<IDataService, DataService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ILoginService, UserAuthenService>();

var app = builder.Build();

app.UseSerilogRequestLogging();
if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/healthz");

app.Run();
