using Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoEntidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoViewModels;
using Entra21.CSharp.ClinicaVeterinaria.Servico.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.InjecoesDependencia
{
    public static class ServicoExtensions
    {
        public static IServiceCollection AdicionarServicos(this IServiceCollection services)
        {
            services.AddScoped<IPetServico, PetServico>();
            services.AddScoped<IRacaServico, RacaServico>();
            services.AddScoped<IVeterinarioServico, VeterinarioServico>();
            services.AddScoped<IResponsavelServico, ResponsavelServico>();
            services.AddScoped<IResponsavelContatoServico, ResponsavelContatoServico>();

            return services;
        }

        public static IServiceCollection AdicionarMapeamentoEntidades(this IServiceCollection services)
        {
            services.AddScoped<IResponsavelContatoMapeamentoEntidade, ResponsavelContatoMapeamentoEntidade>();
            services.AddScoped<IResponsavelMapeamentoEntidade, ResponsavelMapeamentoEntidade>();
            services.AddScoped<IVeterinarioMapeamentoEntidade, VeterinarioMapeamentoEntidade>();
            services.AddScoped<IPetMapeamentoEntidade, PetMapeamentoEntidade>();

            return services;
        }

        public static IServiceCollection AdicionarMapeamentoViewModels(this IServiceCollection services)
        {

            services.AddScoped<IResponsavelViewModelMapeamentoViewModels, ResponsavelViewModelMapeamentoViewModels>();
            services.AddScoped<IResponsavelContatoMapeamentoViewModel, ResponsavelContatoMapeamentoViewModel>();

            return services;
        }
    }
}
