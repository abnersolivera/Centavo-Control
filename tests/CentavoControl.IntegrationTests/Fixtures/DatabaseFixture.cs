using CentavoControl.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Testcontainers.MsSql;

namespace CentavoControl.IntegrationTests.Fixtures;

public class DatabaseFixture : IAsyncLifetime
{
    private readonly MsSqlContainer _container;
    public CentavoControlDbContext DbContext { get; private set; } = null!;

    public DatabaseFixture()
    {
        _container = new MsSqlBuilder()
            .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
            .WithEnvironment("ACCEPT_EULA", "Y")
            .WithEnvironment("SA_PASSWORD", "YourStrong@Passw0rd")
            .WithCleanUp(true)
            .Build();
    }

    public async Task InitializeAsync()
    {
        await _container.StartAsync();

        var connectionString = _container.GetConnectionString();
        var options = new DbContextOptionsBuilder<CentavoControlDbContext>()
            .UseSqlServer(connectionString)
            .Options;

        DbContext = new CentavoControlDbContext(options);
        await DbContext.Database.MigrateAsync();
    }

    public async Task DisposeAsync()
    {
        await DbContext.DisposeAsync();
        await _container.StopAsync();
    }
}

