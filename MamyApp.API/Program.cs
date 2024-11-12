using MamyApp.API.Configuration;
using MamyApp.API.Extensions;
using MamyApp.Logging.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureLogging(builder.Configuration);
builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddRepositoryConfiguration();
builder.Services.AddServiceConfiguration();
builder.Services.AddRedisConfiguration(builder.Configuration);
builder.Services.AddSignalRConfiguration();
builder.Services.ConfigureGeneral();
builder.Services.AddFluentValidationServices();
builder.Services.AddJwtAuthentication(builder.Configuration);



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
