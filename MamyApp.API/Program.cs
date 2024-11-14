using MamyApp.API.Configuration;
using MamyApp.API.Extensions;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

#region Extansions
builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddRepositoryConfiguration();
builder.Services.AddServiceConfiguration();
builder.Services.AddRedisConfiguration(builder.Configuration);
builder.Services.AddSignalRConfiguration();
builder.Services.ConfigureGeneral();
builder.Services.AddFluentValidationServices();
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddCustomSwagger();
#endregion

#region SeriLog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Logging.ClearProviders(); 
builder.Logging.AddSerilog(Log.Logger);
#endregion

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
