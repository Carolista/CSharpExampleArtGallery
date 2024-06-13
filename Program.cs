var builder = WebApplication.CreateBuilder(args);

// TODO 1: Install / verify installation of EF Core
// TODO 2: Setup schema and user privileges in MySQL Workbench
// TODO 3: Add connectionString and serverVersion variables
// TODO 4: Use secrets.json to hide credentials
// TODO 5: Use NuGet Manager to install dependencies

// Add services to the container.
builder.Services.AddControllersWithViews();
// TODO 7: Add DbContext class in Data
// TODO 8: Add service for DbContext with connectionString and serverVersion

// TODO 9: Create & run InitialMigration

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
