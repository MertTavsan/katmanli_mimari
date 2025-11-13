using Microsoft.EntityFrameworkCore;
using katmanli_mimari.Data;
using katmanli_mimari.Services;


var builder = WebApplication.CreateBuilder(args);

// DbContext ekle
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(
        "Data Source=app.db",
        b => b.MigrationsAssembly("katmanli_mimari.Data")));

// Katman servislerini kaydet
builder.Services.AddScoped<Service>();

builder.Services.AddControllersWithViews();




// Add services to the container.
builder.Services.AddControllersWithViews();


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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
