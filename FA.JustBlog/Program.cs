using FA.JustBlog.Core.Context;
using FA.JustBlog.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Get connectionn string from file config
string connnectionString = builder.Configuration.GetConnectionString("SQLConnection");

builder.Services.AddDbContext<JustBlogContext>(opts =>
{
    // Set up connection string for db context
    opts.UseSqlServer(connnectionString);
});

// Use DI (Dependency injection)
// builder.Services.AddScoped<IJustBlogContext,JustBlogContext>();
// builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

// Call static metod to init di
builder.Services.AddInfrastructureServices();

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
