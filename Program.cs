using CSharpExampleArtGallery;
using Microsoft.EntityFrameworkCore;
// TODO 6: Un-comment the using statement below
// using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// TODO 7: Remove whatever additional definition of connectionString has been added here

// Use string saved in secrets.json on local machine instead
var connectionString = builder.Configuration["connectionStringArtGallery2024"];
var serverVersion = new MySqlServerVersion(new Version(8, 0, 34));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ArtworkDbContext>(dbContextOptions =>
    dbContextOptions.UseMySql(connectionString, serverVersion)
);

// TODO 6: Un-comment the two services below
// builder.Services.AddRazorPages();
// builder.Services.AddDefaultIdentity<IdentityUser>(
//     options => { 
//         options.SignIn.RequireConfirmedAccount = false;
//         options.Password.RequireDigit = true;
//         options.Password.RequiredLength = 8;
//         options.Password.RequireNonAlphanumeric = false;
//         options.Password.RequireUppercase = true;
//         options.Password.RequireLowercase = true;
//         options.Lockout.AllowedForNewUsers = false;
//     }).AddEntityFrameworkStores<ArtworkDbContext>();

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

// TODO 7: Un-comment the two lines below
// app.MapRazorPages();
// app.MapControllers();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

/* 
    TODO 1: Look up .NET Core SDK version and create a global.json file

    TODO 2: Use NuGet to install 5 dependencies needed for Identity setup

    TODO 4: Install code generator and list all files available for identity scaffolding

    TODO 5: Run the following command in the terminal:
    dotnet aspnet-codegenerator identity --dbContext ArtworkDbContext --files "Account.Register;Account.Login;Account.Logout;Account._StatusMessage;Account.Manage._Layout;Account.Manage._ManageNav;Account.Manage._StatusMessage;Account.Manage.ChangePassword;Account.Manage.Index"

    TODO 8: Create migration and update database - take a look at tables

    TODO 12: Update Register and Login pages with new layout, styling, and text; remove unneeded content

    TODO 13: Update Manage files with new layout, styling, and text; remove unneeded content
*/