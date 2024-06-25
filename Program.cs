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

// TODO 6: Add services needed for Swagger Docs

// TODO 9: Add services and options needed for CORS policy

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

// TODO 6: Add calls needed for Swagger then test in UI at /swagger

// TODO 9: Add call needed for CORS policy

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

/*  
    TODO 1: Create an Api subfolder in Controllers

    TODO 2: Scaffold API controller class using code gen:
    dotnet aspnet-codegenerator controller -name ArtworksController -async -api -m Artwork -dc ArtworkDbContext -outDir Controllers/Api

    TODO 3: Edit GET methods to include artist, categories, and details
        Try making a request in browser address bar and note circular references

    TODO 4: Create ArtworkDTO model to shape data as needed for transfer; update controller
        Make a request in browser address bar and select pretty print

    TODO 5: Add Swagger Docs dependencies:
            Swashbuckle.AspNetCore.SwaggerGen
            Swashbuckle.AspNetCore.SwaggerUI

    TODO 7: Delete PUT/POST DELETE from API controller and view updated Swagger documentation

    TODO 8: Spin up front end apps in order to demonstrate CORS blocks

    TODO 10: Demo front end apps using data fetched from this app
*/