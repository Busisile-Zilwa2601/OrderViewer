using OrderViewer.Web.Interfaces;
using OrderViewer.Web.Services;
using OrderViewer.Web.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<IOrderService, OrderViewerService>();

builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IOrderService, OrderViewerService>();

SD.OrderAPIBase = builder.Configuration["ServiceUrls:OrderAPI"];
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
