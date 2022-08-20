using ASP_FinalExam_Net6.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase(databaseName: "FinalExamDB"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase(databaseName: "FinalExam"));
// Google authentication
object value = builder.Services.AddAuthentication().AddGoogle(googleOptions =>
{
    //for using the JSON authentication
    //googleOptions.ClientId = builder.Configuration["Google:Authentication:clientid"];
    googleOptions.ClientId = "842113652126-lheqdsb8hua2pk7remb3stchfc9l7elb.apps.googleusercontent.com";
    googleOptions.ClientSecret = "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";
});

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
