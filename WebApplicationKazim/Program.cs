
namespace WebApplicationKazim;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddScoped<IMonitoredEntityRepository, MonitoredEntityRepository>(
            x => 
                new MonitoredEntityRepository(
                    "Data Source=DEV-LT-KAZIMR; Initial Catalog=MonitoredEntityTable; Integrated Security=true; TrustServerCertificate=True"
                    ));
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}