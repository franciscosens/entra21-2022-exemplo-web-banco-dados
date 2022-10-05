using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Consultas;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.ConsultasProcedimentos;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.Servicos
{
    public interface IConsultaServico
    {
        Consulta Cadastrar(ConsultaCadastrarViewModel viewModel);
        List<ConsultaIndexViewModel> ObterTodos();
        void Iniciar(ConsultaIniciarViewModel viewModel);
        void Cancelar(ConsultaCancelarViewModel viewModel);
        void Finalizar(ConsultaFinalizarViewModel viewModel);
        void AdicionarProcedimento(ConsultaAdicionarProcedimentoViewModel viewModel);
    }
}