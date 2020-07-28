using Cembjr.ControleFrota.Business.Interfaces;
using Cembjr.ControleFrota.Data.Context;
using Cembjr.ControleFrota.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Cembjr.ControleFrota.UI.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ControleFrotaContext>();
            services.AddScoped<IAtendenteRepository, AtendenteRepository>();
            services.AddScoped<IMotoristaRepository, MotoristaRepository>();
            services.AddScoped<IServicoRepository, ServicoRepository>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            
            return services;
        }
    }
}
