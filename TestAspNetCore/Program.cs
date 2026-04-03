
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TestAspNetCore.Data;
using TestAspNetCore.Repository;
using TestAspNetCore.Repository.Base;
using TestAspNetCore.UnitOFWork;
using TestAspNetCore.UnitOFWork.Base;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AppDbContext>();
//builder.Services.AddTransient(typeof(IRepository<>), typeof(MainRepository<>));
builder.Services.AddTransient<IUnitOFWork, MianUnitOfWork>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();
//app.MapRazorPages();
app.MapStaticAssets();
app.MapControllerRoute(
    name: "area",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
