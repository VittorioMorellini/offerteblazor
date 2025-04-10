using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using MudBlazor.Services;
using OfferteWeb;
using OfferteWeb.Models;
using OfferteWeb.Models.Auth;
using OfferteWeb.Services;
using OfferteWeb.State;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    //.MinimumLevel.Information()
    //.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    //.WriteTo.RollingFile("logs/{Date}.txt")
    .CreateLogger();

builder.Logging.AddSerilog(logger);

// Custom metrics for the application
//var greeterMeter = new Meter("OtPrGrYa.Example", "1.0.0");
//var countGreetings = greeterMeter.CreateCounter<int>("greetings.count", description: "Counts the number of greetings");
////// Custom ActivitySource for the application
//var greeterActivitySource = new ActivitySource("OtPrGrJa.Example");

//var tracingOtlpEndpoint = builder.Configuration["OTLP_ENDPOINT_URL"]; 
//var otel = builder.Services.AddOpenTelemetry();
//// Configure OpenTelemetry Resources with the application name
//otel.ConfigureResource(resource => resource
//    .AddService(serviceName: builder.Environment.ApplicationName));
//// Add Metrics for ASP.NET Core and our custom metrics and export to Prometheus
//otel.WithMetrics(metrics => metrics
//    // Metrics provider from OpenTelemetry
//    .AddAspNetCoreInstrumentation()
//    .AddMeter(greeterMeter.Name)
//    // Metrics provides by ASP.NET Core in .NET 8
//    .AddMeter("Microsoft.AspNetCore.Hosting")
//    .AddMeter("Microsoft.AspNetCore.Server.Kestrel")
//    .AddPrometheusExporter());

//// Add Tracing for ASP.NET Core and our custom ActivitySource and export to Jaeger
//otel.WithTracing(tracing =>
//{
//    tracing.AddAspNetCoreInstrumentation();
//    tracing.AddHttpClientInstrumentation();
//    tracing.AddSource(greeterActivitySource.Name);
//    if (tracingOtlpEndpoint != null)
//    {
//        tracing.AddOtlpExporter(otlpOptions =>
//        {
//            otlpOptions.Endpoint = new Uri(tracingOtlpEndpoint);
//        });
//    }
//    else
//    {
//        tracing.AddConsoleExporter();
//    }
//});

builder.Services.AddDbContext<OfferteDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Offerte")),
    // è necessario che sia Transient poichè ho necessità di compiere azioni asincrone
    // ogni Service così ha la propria versione unica di DocDsDbContext (con la propria connessione)
    ServiceLifetime.Transient
);
            
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddServerSideBlazor();
//builder.Services.AddCascadingAuthenticationState();

builder.Services.AddSingleton(new AuthContext()
{
    JWTSecretKey = builder.Configuration["Auth:JWTSecretKey"],
    JWTLifespan = builder.Configuration["Auth:JWTLifespan"],
});
builder.Services.AddSingleton(new AppConfiguration()
{
    BaseAddress = builder.Configuration["AppConfiguration:BaseAddress"],
    B64key = builder.Configuration["AppConfiguration:B64key"],
});
builder.Services.AddSingleton(new EmailConfiguration()
{
    SmtpServer = builder.Configuration["EmailConfiguration:SmtpServer"],
    SmtpUser = builder.Configuration["EmailConfiguration:SmtpUser"],
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
//builder.Services.AddScoped<InitialApplicationStateHandler>();

//builder.Services.AddScoped<ProtectedSessionStorage>();
//builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddHttpClient();
builder.Services.AddScoped<SearchModelStore>();
builder.Services.AddScoped<IAgenteService, AgenteService>();
builder.Services.AddScoped<IAgenteGruppoService, AgenteGruppoService>();
builder.Services.AddScoped<IOffertaService, OffertaService>();
builder.Services.AddScoped<IOffertaRigaService, OffertaRigaService>();
builder.Services.AddScoped<ITipoProdottoService, TipoProdottoService>();
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<ICliComService, CliComService>();
builder.Services.AddScoped<ICirComService, CirComService>();
builder.Services.AddScoped<IGenericEntityService, GenericEntityService>();
builder.Services.AddScoped<ITipoProdottoService, TipoProdottoService>();
builder.Services.AddScoped<IGrafiteService, GrafiteService>();
builder.Services.AddScoped<IValutaService, ValutaService>();

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
builder.Services.AddScoped<EntitiesFactory>();
builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.MapGet("/", SendGreeting);
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// Configure the Prometheus scraping endpoint
//app.MapPrometheusScrapingEndpoint();

app.Run();

//async Task<String> SendGreeting(ILogger<Program> logger)
//{
//    // Create a new Activity scoped to the method
//    using var activity = greeterActivitySource.StartActivity("GreeterActivity");

//    // Log a message
//    logger.LogInformation("Sending greeting");

//    // Increment the custom counter
//    countGreetings.Add(1);

//    // Add a tag to the Activity
//    activity?.SetTag("greeting", "Hello World!");

//    return "Hello World!";
//}

