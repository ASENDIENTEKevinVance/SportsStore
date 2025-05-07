using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsStore.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StoreDBContext>(opts =>
	{
		opts.UseSqlServer(builder.Configuration["ConnectionStrings:SportsStoreConnection"]);
	});

builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();
builder.Services.AddScoped<IOrderRepository, EFOrderRepository>();
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
builder.Services.AddSingleton<IHttpContextAccessor,
	HttpContextAccessor > ();


var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.UseStaticFiles();
app.UseSession();

app.MapControllerRoute("catpage",
	"{category}/Page{productPage:int}", 
	new { Controller = "Home", action = "Index" });

app.MapControllerRoute("page",
	"Page{productPage:int}",
	new { Controller = "Home", action = "Index", productPage = 1});

app.MapControllerRoute("category",
	"{category}",
	new { Controller = "Home", action = "Index", productPage = 1 });

app.MapControllerRoute("pagination",
	"Products/Page{productPage}",
	new { Controller = "Home", action = "Index", productPage = 1 });

app.MapDefaultControllerRoute();
app.MapRazorPages();
if (app.Environment.IsDevelopment())
{
app.UseDeveloperExceptionPage(); // Add this
}
else
{
app.UseExceptionHandler("/Error");
}

//SeedData.EnsurePopulated(app);
try
{
    SeedData.EnsurePopulated(app);
}
catch (Exception ex)
{
    // Just log the error and continue - this allows the app to start
    // even if there are database issues
    Console.WriteLine("Error during database seeding: " + ex.Message);
}

app.Run();
