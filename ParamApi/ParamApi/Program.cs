using ParamApi.Extension;
using Serilog;

//Read configuration from appSettings
var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

//Initialize Logger
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(config).CreateLogger();
Log.Information("App is starting.");


var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDBContextDI(config);
builder.Services.AddServiceDI();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
