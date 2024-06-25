using CSharpExampleArtGallery;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Use string saved in secrets.json on local machine instead
var connectionString = builder.Configuration["connectionStringArtGallery2024"];
var serverVersion = new MySqlServerVersion(new Version(8, 0, 34));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ArtworkDbContext>(dbContextOptions =>
    dbContextOptions.UseMySql(connectionString, serverVersion)
);

builder.Services.AddRazorPages();
builder.Services.AddDefaultIdentity<IdentityUser>(
    options => { 
        options.SignIn.RequireConfirmedAccount = false;
        options.Password.RequireDigit = true;
        options.Password.RequiredLength = 8;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = true;
        options.Password.RequireLowercase = true;
        options.Lockout.AllowedForNewUsers = false;
    }).AddEntityFrameworkStores<ArtworkDbContext>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var specificOrigins = "AppOrigins";
builder.Services.AddCors(options => {
    // Allow Angular app to connect
    options.AddPolicy(name: specificOrigins, policy => policy.WithOrigins("http://localhost:4200"));
    // Allow React app to connect
    options.AddPolicy(name: specificOrigins, policy => policy.WithOrigins("http://127.0.0.1:5173"));
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

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(specificOrigins);

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
