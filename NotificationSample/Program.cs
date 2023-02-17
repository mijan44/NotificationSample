using Microsoft.EntityFrameworkCore;
using NotificationSample.Data;
using NotificationSample.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var webApplicationBuilder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
    connectionString: builder.Configuration.GetConnectionString("DefaultConnection")

    ));



builder.Services.AddRazorPages();
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseHttpsRedirection();
app.UseStaticFiles();



app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<NotificationHub>("/notificationHub");
});

app.Run();