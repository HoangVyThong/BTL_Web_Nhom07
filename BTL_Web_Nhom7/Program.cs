using BTL_Web_Nhom7.Models;
using BTL_Web_Nhom7.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("BtlApiContext");
builder.Services.AddDbContext<BtlApiContext>(option => option.UseSqlServer(connectionString));
builder.Services.AddScoped<IDanhMucRepository, DanhMucRepository>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddAuthentication()
    .AddGoogle(options =>
    {
        options.ClientId = builder.Configuration["App:GoogleClientId"];
        options.ClientSecret = builder.Configuration["App:GoogleClientSecret"];
    })
    .AddFacebook(options =>
    {
        options.AppId = builder.Configuration["App:FacebookClientId"];
        options.ClientSecret = builder.Configuration["App:FacebookClientSecrets"];
    });
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10000000);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
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
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=BanHang}/{action=TrangChu}/{id?}");

app.Run();
