using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Notifcations.Hubs;
using Notifcations.Hubs.ServicesHub;
using Notifcations.Models;
using Notifcations.Models.Entities;
using Notifcations.Utlties.Configurtions;
using Notifcations.Utlties.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate();
builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});
builder.Services.AddDbContext<AppDbContext>(
                        options => options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("Connect")));
builder.Services.AddIdentity<Appuser, IdentityRole>()
                             .AddEntityFrameworkStores<AppDbContext>()
                             .AddDefaultTokenProviders();
builder.Services.AddScoped<IServices, Services>();
builder.Services.AddSingleton<IUserConnectionManager, UserConnectionManager>();
builder.Services.Configure<IdentityOptions>(o =>
{
    o.Password.RequireDigit = false;
    o.Password.RequireLowercase = false;
    o.Password.RequireUppercase = false;
    o.Password.RequireNonAlphanumeric = false;
    o.Password.RequiredLength = 5;
});
builder.Services.AddMvc(option =>
{
    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                   .Build();
    option.Filters.Add(new AuthorizeFilter(policy));

}).AddXmlSerializerFormatters();
builder.Services.AddSignalR();
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseDefaultFiles();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapHub<NotificationUserHub>("/NotificationUserHub");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Register}/{id?}");

app.Run();

