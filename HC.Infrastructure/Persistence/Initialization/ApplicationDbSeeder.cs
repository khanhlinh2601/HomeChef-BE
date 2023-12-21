namespace HC.Infrastructure.Persistence.Initialization;

internal class ApplicationDbSeeder
{

    private readonly CustomSeederRunner _seederRunner;

    public ApplicationDbSeeder(CustomSeederRunner seederRunner)
    {
        _seederRunner = seederRunner;
    }
    public async Task SeedDatabaseAsync(CancellationToken cancellationToken)
    {
        await _seederRunner.RunSeedersAsync(cancellationToken);
    }


}