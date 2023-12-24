using Serilog;
using HC.Infrastructure;

Log.Information("Starting web host");
try
{
    var builder = WebApplication.CreateBuilder(args);

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