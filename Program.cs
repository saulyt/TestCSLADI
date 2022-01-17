using Csla.Configuration;
using Serilog;
using Serilog.Extensions.Logging;
using TestCSLADI.Library;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<ITestDI, TestDI>();
builder.Services.AddCsla();

using var logger = new LoggerConfiguration()
    .WriteTo.Console().MinimumLevel.Debug()
    .CreateLogger();
//builder.Services.AddLogging(lb => lb.AddSerilog(logger));
var iLogger = new SerilogLoggerProvider(logger).CreateLogger(nameof(Program));
builder.Services.AddSingleton(iLogger);


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

try
{
    Log.Information("Starting web host");
    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}

