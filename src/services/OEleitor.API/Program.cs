using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using OEleitor.API.Configuration;
using OEleitor.Infra.Data.Configuration;
using OEleitor.Infra.IoC.IOC;
using OEleitor.Logs.Extensions;

var builder = WebApplication.CreateBuilder(args);

SerilogSetup.ConfigureSerilog(builder.Configuration);
builder.Host.UsingSerilog();

//builder.Configuration
//    .SetBasePath(builder.Environment.ContentRootPath)
//    .AddJsonFile("appsettings.json", true, true)
//    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
//    .AddEnvironmentVariables();

var connectionStr = builder.Configuration.GetConnectionString("OEleitorConnection");

builder.Services.AddIdentityConfiguration(builder.Configuration);

builder.Services.AddDbInjector();

builder.Services.AddControllers(o =>
{
    o.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
}).AddNewtonsoftJson(o =>
{
    o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});

//builder.Services.AddApiConfiguration();

var assembly = AppDomain.CurrentDomain.Load("OEleitor.Application");
builder.Services.AddMediatR(assembly);
builder.Services.AddMediatorInjector();
builder.Services.AddAutoMapperInjector();
builder.Services.AddServicesInjector();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Development",
        b =>
            b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
    );
});

builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

app.EnsureMigrationsApplied();

app.UseHttpsRedirection();

app.UseCors(x =>
x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment() ||
    app.Environment.IsEnvironment("Homolog") ||
    app.Environment.IsEnvironment("Development-local")
   )
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
