using BTL_Web_Nhom7.Models;
using BTL_Web_Nhom7.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("BtlWebContext");
builder.Services.AddDbContext<BtlWebContext>(option => option.UseSqlServer(connectionString));
builder.Services.AddScoped<IDanhMucRepository, DanhMucRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=BanHang}/{action=TrangChu}/{id?}");

app.Run();
