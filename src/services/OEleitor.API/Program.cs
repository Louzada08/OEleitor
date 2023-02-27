using MediatR;
using Newtonsoft.Json;
using OEleitor.API.Configuration;
using OEleitor.Infra.CrossCurtting.Identidade;
using OEleitor.Infra.IoC.IOC;
using OEleitor.Logs.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

var connectionStr = builder.Configuration.GetConnectionString("OEleitorConnection");

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("JWT"));
builder.Services.AddDbContextInjector(connectionStr);

SerilogSetup.ConfigureSerilog(builder.Configuration);
builder.Host.UsingSerilog();

builder.Services.AddDbInjector();

builder.Services.AddIdentityConfiguration(builder.Configuration);

var assembly = AppDomain.CurrentDomain.Load("OEleitor.API");
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

builder.Services.AddApiConfiguration();

builder.Services.AddSwaggerConfiguration();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

//app.EnsureMigrationsApplied();

app.UseSwaggerConfiguration();
app.UseApiConfiguration(app.Environment);



//if (app.Environment.IsDevelopment() ||
//    app.Environment.IsEnvironment("Homolog") ||
//    app.Environment.IsEnvironment("Development-local")
//   )
//{
//}
//app.UseHttpsRedirection();


//app.MapControllers();

app.Run();
