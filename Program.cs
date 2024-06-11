using CSharpExampleArtGallery;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

/* 
    General pattern:
    var connectionString = "server=localhost;user=username;password=password;database=database";
*/

// Use string saved in secrets.json on local machine instead
var connectionString = builder.Configuration["connectionStringMVCTest"];
var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ArtworkDbContext>(dbContextOptions => dbContextOptions.UseMySql(connectionString, serverVersion));

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
