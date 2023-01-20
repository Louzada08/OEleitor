using MediatR;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using OEleitor.API.Configuration;
using OEleitor.Infra.Data.Configuration;
using OEleitor.Infra.IoC.IOC;
using OEleitor.Logs.Extensions;

var builder = WebApplication.CreateBuilder(args);

SerilogSetup.ConfigureSerilog(builder.Configuration);

builder.Host.UsingSerilog();

var connectionStr = builder.Configuration.GetConnectionString("OEleitorConnection");

builder.Services.AddDbContextInjector(connectionStr);
builder.Services.AddDbInjector();

builder.Services.AddControllers(o =>
{
    o.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
}).AddNewtonsoftJson(o =>
{
    o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});

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

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "OEleitor API", Version = "v1" });
    c.CustomSchemaIds(i => i.FullName);
    c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Insira apenas o token, sem a palavra-chave 'Bearer'",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer",
    });

    c.OperationFilter<AuthenticationRequirementsOperationFilter>();
});


var app = builder.Build();

app.EnsureMigrationsApplied();

app.UseHttpsRedirection();

app.UseCors(x =>
x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() ||
    app.Environment.IsEnvironment("Homolog")
   )
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
