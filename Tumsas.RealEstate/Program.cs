using Microsoft.EntityFrameworkCore;
using Tumsas.RealEstate.Business;
using Tumsas.RealEstate.DataAccess.EntityFrameworkCore;
using Tumsas.RealEstate.Extensions;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Host.ConfigureAppConfiguration((_, builder) =>
        {
            builder.AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", false, true)
                .AddEnvironmentVariables();
        });

        builder.Services.AddAutoMapper(typeof(RealEstateAutoMapperProfile));

        builder.Services.AddCollection();

        builder.Services.AddDbContext<RealEstateDbContext>(options => options.UseSqlServer(builder.Configuration["RealEstate:ConStr"]));

        // Add services to the container.
        builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

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

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}