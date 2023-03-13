using DataLayer.Context;
using DataLogic.Repositories;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.Services.AddAuthorizationCore();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ClientRepository>();
builder.Services.AddScoped<InvoiceDetailRepository>();
builder.Services.AddScoped<InvoiceRepository>();
builder.Services.AddScoped<NcfRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
