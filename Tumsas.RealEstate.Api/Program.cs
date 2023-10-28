using Microsoft.EntityFrameworkCore;
using Tumsas.RealEstate.Api.Extensions;
using Tumsas.RealEstate.Business;
using Tumsas.RealEstate.DataAccess.EntityFrameworkCore;

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

        // Cors
        const string corsPolicyName = "ApiCORS";

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(corsPolicyName, policy =>
            {
                policy.WithOrigins(builder.Configuration["App:CorsOrigins"].Split(","));
            });
        });

        // Add services to the container.
        builder.Services.AddAutoMapper(typeof(RealEstateAutoMapperProfile));

        builder.Services.AddCollection();

        builder.Services.AddDbContext<RealEstateDbContext>(options => options.UseSqlServer(builder.Configuration["RealEstate:ConStr"]));

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors(corsPolicyName);

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}