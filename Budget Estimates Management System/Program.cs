using Budget_Estimates_Management_System.Authentication;
using Budget_Estimates_Management_System.Models;
using DataAccessLibrary;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Budget_Estimates_Management_System.Services;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
//Data Services
builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddTransient<IDbData, DbData>();
builder.Services.AddTransient<IRecEstimateData, RecEstimateData>();
builder.Services.AddTransient<INotificationData, NotificationData>();
//Authentication
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
//Email Servies
builder.Services.AddScoped<IEmailService, EmailService>();

//build app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
