using DTEPortal.Data;
using DTEPortal.Services.Contract;
using DTEPortal.Services.Repository;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using NewCoreApp.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Register the DbContext (no need to pass the connection string here)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));  // Optional: If you still want to use settings from appsettings.json

builder.Services.AddControllersWithViews();
builder.Services.InstallServices(builder.Configuration, typeof(IServiceInstaller).Assembly);
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.Configure<RazorViewEngineOptions>(o =>
{
	o.ViewLocationFormats.Clear();
	o.ViewLocationFormats.Add("/Views/Masters/{1}/{0}" + RazorViewEngine.ViewExtension);
	o.ViewLocationFormats.Add("/Views/Masters/LocationMaster/{1}/{0}" + RazorViewEngine.ViewExtension);
	
});

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
    pattern: "{controller=StateMaster}/{action=Index}/{id?}");

app.Run();
