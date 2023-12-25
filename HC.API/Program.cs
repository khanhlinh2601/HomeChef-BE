using Serilog;
using HC.Infrastructure;
using HC.Infrastructure.Common;
using HC.API.Configurations;

using HC.Infrastructure.Logging.Serilog;

StaticLogger.EnsureInitialized();
Log.Information("Starting web host");
try
{
    var builder = WebApplication.CreateBuilder(args);
    
    builder.AddConfigurations().RegisterSerilog();
    builder.Services.AddControllers();
    builder.Services.AddInfrastructure(builder.Configuration);

    var app = builder.Build();
    app.UseInfrastructure(builder.Configuration);
    app.MapEndpoints();
    app.Run();
}
catch (Exception ex) when (!ex.GetType().Name.Equals("StopTheHostException", StringComparison.Ordinal))
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Server Shutting down...");
    Log.CloseAndFlush();
}