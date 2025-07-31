using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderViewer.Service.OrderAPI.ContextData;
using OrderViewer.Service.OrderAPI.Interfaces;
using OrderViewer.Service.OrderAPI.Logging;
using OrderViewer.Service.OrderAPI.Mappings;
using OrderViewer.Service.OrderAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<OrderService_DbContext>(option => option.UseSqlServer(connectionString));

//Add custom logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();
var logPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs" ,"log.txt");
if (!string.IsNullOrWhiteSpace(logPath)) 
{
    var directory = Path.GetDirectoryName(logPath);
    if (!string.IsNullOrWhiteSpace(directory) && !Directory.Exists(directory))
    { 
        Directory.CreateDirectory(directory);
    }
}
builder.Logging.AddProvider(new FileLoggerProvider(logPath));

builder.Services.AddControllers();

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IOrderService, OrderService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

ApplyMigration();

app.Run();


void ApplyMigration()
{
    using var scope = app.Services.CreateScope();
    var _db = scope.ServiceProvider.GetRequiredService<OrderService_DbContext>();

    if (_db.Database.GetPendingMigrations().Any())
    {
        _db.Database.Migrate();
    }
}
