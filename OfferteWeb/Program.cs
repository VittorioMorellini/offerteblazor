using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using MudBlazor.Services;
using OfferteWeb.Authentication;
using OfferteWeb.Data;
using OfferteWeb.Models;
using OfferteWeb.Models.Auth;
using OfferteWeb.Services;
using OfferteWeb.State;
using Serilog;

namespace OfferteWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                //.MinimumLevel.Information()
                //.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                //.WriteTo.RollingFile("logs/{Date}.txt")
                .CreateLogger();

            builder.Logging.AddSerilog(logger);
            
            builder.Services.AddDbContext<OfferteDbContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("Offerte")),
                // è necessario che sia Transient poichè ho necessità di compiere azioni asincrone
                // ogni Service così ha la propria versione unica di DocDsDbContext (con la propria connessione)
                ServiceLifetime.Transient
            );
            
            builder.Services.AddRazorPages()
                .AddRazorRuntimeCompilation();
            builder.Services.AddServerSideBlazor();
            //builder.Services.AddCascadingAuthenticationState();

            // Add services to the container.
            //builder.Services.AddAuthentication(options =>
            //{
            //    options.DefaultScheme = "CustomScheme";
            //})
            //.AddScheme<CustomAuthenticationHandlerOptions, CustomAuthenticationHandler>("CustomScheme", null);
            //builder.Services.AddAuthenticationCore();
            builder.Services.AddSingleton(new AuthContext()
            {
                JWTSecretKey = builder.Configuration["Auth:JWTSecretKey"],
                JWTLifespan = builder.Configuration["Auth:JWTLifespan"],
            });
            builder.Services.AddScoped<ProtectedSessionStorage>();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            //builder.Services.AddBlazoredSessionStorage();
            builder.Services.AddScoped<IAgenteService, AgenteService>();
            builder.Services.AddScoped<IAgenteGruppoService, AgenteGruppoService>();

            builder.Services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = MudBlazor.Defaults.Classes.Position.BottomCenter;
                config.SnackbarConfiguration.ClearAfterNavigation = true;
                config.SnackbarConfiguration.MaxDisplayedSnackbars = 3;
                config.SnackbarConfiguration.PreventDuplicates = true;
                config.SnackbarConfiguration.NewestOnTop = true;
                config.SnackbarConfiguration.ShowCloseIcon = true;
                config.SnackbarConfiguration.VisibleStateDuration = 5000;
                config.SnackbarConfiguration.HideTransitionDuration = 500;
                config.SnackbarConfiguration.ShowTransitionDuration = 500;
                config.SnackbarConfiguration.SnackbarVariant = MudBlazor.Variant.Filled;
            });

            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<AppState>();

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
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}
