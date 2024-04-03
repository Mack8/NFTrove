using Microsoft.EntityFrameworkCore;
using NFTrove.Application.Profiles;
using NFTrove.Application.Services.Implementations;
using NFTrove.Application.Services.Interfaces;
using NFTrove.Infraestructure.Data;
using NFTrove.Infraestructure.Repository.Implementation;
using NFTrove.Infraestructure.Repository.Interfaces;
using Serilog;
using Serilog.Events;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var logger = new LoggerConfiguration()
                    //.MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                    .Enrich.FromLogContext()
                    .WriteTo.Console(LogEventLevel.Verbose)
                    .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Information).WriteTo.File(@"Logs\Info-.log", shared: true, encoding: Encoding.ASCII, rollingInterval: RollingInterval.Day))
                    .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Debug).WriteTo.File(@"Logs\Debug-.log", shared: true, encoding: System.Text.Encoding.ASCII, rollingInterval: RollingInterval.Day))
                    .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Warning).WriteTo.File(@"Logs\Warning-.log", shared: true, encoding: System.Text.Encoding.ASCII, rollingInterval: RollingInterval.Day))
                    .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Error).WriteTo.File(@"Logs\Error-.log", shared: true, encoding: Encoding.ASCII, rollingInterval: RollingInterval.Day))
                    .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Fatal).WriteTo.File(@"Logs\Fatal-.log", shared: true, encoding: Encoding.ASCII, rollingInterval: RollingInterval.Day))
                    .CreateLogger();

builder.Host.UseSerilog(logger);

//DI

builder.Services.AddTransient<IRepositoryCliente, RepositoryCliente>();
builder.Services.AddTransient<IServiceCliente, ServiceCliente>();
builder.Services.AddTransient<IRepositoryTarjeta, RepositoryTarjeta>();
builder.Services.AddTransient<IServiceTarjeta, ServiceTarjeta>();
builder.Services.AddTransient<IRepositoryPais, RepositoryPais>();
builder.Services.AddTransient<IServicePais, ServicePais>();
builder.Services.AddTransient<IServiceNft, ServiceNft>();
builder.Services.AddTransient<IRepositoryNft, RepositoryNft>();
builder.Services.AddTransient<IRepositoryFactura, RepositoryFactura>();
builder.Services.AddTransient<IServiceFactura, ServiceFactura>();


builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<ClienteProfile>();
    config.AddProfile<TarjetaProfile>();
    config.AddProfile<PaisProfile>();
    config.AddProfile<NftProfile>();
    config.AddProfile<FacturaProfile>();
});


builder.Services.AddDbContext<NFTroveContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerDataBase"));

    if (builder.Environment.IsDevelopment())
        options.EnableSensitiveDataLogging();
});



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
