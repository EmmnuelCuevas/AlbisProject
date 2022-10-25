using DataLayer.Context;
using DataLogic.Repositories;
using Microsoft.AspNetCore.Components.WebView.Maui;
using POS_MauiApp.Data;

namespace POS_MauiApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
        // for debuggin only    
        builder.Services.AddBlazorWebViewDeveloperTools();
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        builder.Services.AddAuthorizationCore();
        builder.Services.AddDbContext<AppDbContext>();
        builder.Services.AddScoped<ProductRepository>();
        builder.Services.AddScoped<ClientRepository>();
        builder.Services.AddScoped<InvoiceDetailRepository>();
        builder.Services.AddScoped<InvoiceRepository>();
        builder.Services.AddScoped<ProjectRepository>();
        return builder.Build();
	}
}
