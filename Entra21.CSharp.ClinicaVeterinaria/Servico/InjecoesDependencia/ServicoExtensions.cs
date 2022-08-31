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
            services.AddScoped<IConsultaServico, ConsultaServico>();
            services.AddScoped<IExameServico, ExameServico>();
            services.AddScoped<IPetServico, PetServico>();
            services.AddScoped<IRacaServico, RacaServico>();
            services.AddScoped<IResponsavelContatoServico, ResponsavelContatoServico>();
            services.AddScoped<IResponsavelServico, ResponsavelServico>();
            services.AddScoped<IVeterinarioServico, VeterinarioServico>();

            return services;
        }

        public static IServiceCollection AdicionarMapeamentoEntidades(this IServiceCollection services)
        {
            services.AddScoped<IConsultaMapeamentoEntidade, ConsultaMapeamentoEntidade>();
            services.AddScoped<IResponsavelContatoMapeamentoEntidade, ResponsavelContatoMapeamentoEntidade>();
            services.AddScoped<IResponsavelMapeamentoEntidade, ResponsavelMapeamentoEntidade>();
            services.AddScoped<IVeterinarioMapeamentoEntidade, VeterinarioMapeamentoEntidade>();
            services.AddScoped<IPetMapeamentoEntidade, PetMapeamentoEntidade>();
            services.AddScoped<IExameMapeamentoEntidade, ExameMapeamentoEntidade>();

            return services;
        }

        public static IServiceCollection AdicionarMapeamentoViewModels(this IServiceCollection services)
        {
            services.AddScoped<IConsultaMapeamentoViewModel, ConsultaMapeamentoViewModel>();
            services.AddScoped<IExameMapeamentoViewModel, ExameMapeamentoViewModel>();
            services.AddScoped<IResponsavelContatoMapeamentoViewModel, ResponsavelContatoMapeamentoViewModel>();
            services.AddScoped<IResponsavelViewModelMapeamentoViewModels, ResponsavelViewModelMapeamentoViewModels>();

            return services;
        }
    }
}