using Microsoft.EntityFrameworkCore;
using WebApplicationKazim.Interfaces;
using WebApplicationKazim.Models;

namespace WebApplicationKazim;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        // Add services to the container.

        builder.Services.AddControllers();

        builder.Services.AddScoped<IMonitoredEntityContext, MonitoredEntityContext>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}