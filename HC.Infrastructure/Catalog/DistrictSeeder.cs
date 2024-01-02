using System.Reflection;
using HC.Application.Common.Interfaces;
using HC.Domain.Entities;
using HC.Infrastructure.Persistence.Context;
using HC.Infrastructure.Persistence.Initialization;
using Microsoft.Extensions.Logging;

namespace HC.Infrastructure.Catalog;

public class DistrictSeeder : ICustomSeeder
{
    private readonly ISerializerService _serializerService;
    private readonly ApplicationDbContext _db;
    private readonly ILogger<DistrictSeeder> _logger;

    public DistrictSeeder(ISerializerService serializerService, ApplicationDbContext db, ILogger<DistrictSeeder> logger)
    {
        _serializerService = serializerService;
        _db = db;
        _logger = logger;
    }
    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        string? path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (!_db.Districts.Any())
        {
            _logger.LogInformation("Started to Seed district.");

            // Here you can use your own logic to populate the database.
            // As an example, I am using a JSON file to populate the database.
            string districtData = await File.ReadAllTextAsync(path + "/Catalog/districts.json", cancellationToken);
            var districts = _serializerService.Deserialize<List<District>>(districtData);

            if (districts != null)
            {
                foreach (var district in districts)
                {
                    await _db.Districts.AddAsync(district, cancellationToken);
                }
            }

            await _db.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Seeded district.");
        }
         



    }
}