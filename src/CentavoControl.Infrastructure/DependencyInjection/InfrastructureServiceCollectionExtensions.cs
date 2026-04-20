using CentavoControl.Domain.Interfaces;
using CentavoControl.Infrastructure.Persistence;
using CentavoControl.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CentavoControl.Infrastructure.DependencyInjection;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<CentavoControlDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IContaRepository, ContaRepository>();
        services.AddScoped<ITransacaoRepository, TransacaoRepository>();
        services.AddScoped<ITransferenciaRepository, TransferenciaRepository>();
        services.AddScoped<ICartaoCreditoRepository, CartaoCreditoRepository>();
        services.AddScoped<IFaturaRepository, FaturaRepository>();
        services.AddScoped<ICategoriaRepository, CategoriaRepository>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        return services;
    }
}

