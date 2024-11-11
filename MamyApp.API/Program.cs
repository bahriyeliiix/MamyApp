using MamyApp.API.Extensions;
using MamyApp.Logging.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
          .WriteTo.Console()
          .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
          .CreateLogger();

builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddRepositoryConfiguration();
builder.Services.AddServiceConfiguration();
builder.Services.AddLoggingConfiguration();
builder.Services.AddRedisConfiguration(builder.Configuration);
builder.Services.AddSignalRConfiguration();
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.ConfigureLogging(builder.Configuration);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
