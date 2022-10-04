using Entra21.CSharp.ClinicaVeterinaria.Repositorio.BancoDados;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.InjecoesDependencia
{
    public static class RepositorioExtensions
    {
        public static IServiceCollection AdicionarRepositorios(this IServiceCollection services)
        {
            services.AddScoped<IPetRepositorio, PetRepositorio>();
            services.AddScoped<IRacaRepositorio, RacaRepositorio>();
            services.AddScoped<IVeterinarioRepositorio, VeterinarioRepositorio>();
            services.AddScoped<IResponsavelRepositorio, ResponsavelRepositorio>();
            services.AddScoped<IResponsavelContatoRepositorio, ResponsavelContatoRepositorio>();
            
            services.AddScoped<IConsultaRepositorio, ConsultaRepositorio>();

            return services;
        }

        public static IServiceCollection AdicionarEntityFramework(
            this IServiceCollection services, ConfigurationManager configurationManager)
        {
            services.AddDbContext<ClinicaVeterinariaContexto>(options =>
                options.UseSqlServer(configurationManager.GetConnectionString("SqlServer")));

            return services;
        }
    }
}
