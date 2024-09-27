var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "Payments",
    pattern: "{controller=Home}/{action=Payments}/{id?}");

app.MapControllerRoute(
    name: "ContactInfo",
    pattern: "{controller=Home}/{action=ContactInfo}/{id?}");

app.MapControllerRoute(
    name: "MyItems",
    pattern: "{controller=Home}/{action=MyItems}/{id?}");

app.MapControllerRoute(
    name: "CalendarAndEvents",
    pattern: "{controller=Home}/{action=MyItems}/{id?}");

app.MapControllerRoute(
    name: "MyItems",
    pattern: "{controller=Home}/{action=Directory}/{id?}");

app.MapControllerRoute(
    name: "MyItems",
    pattern: "{controller=Home}/{action=Documents}/{id?}");

app.Run();
