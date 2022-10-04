using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Consultas;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.Servicos
{
    public interface IConsultaServico
    {
        Consulta Cadastrar(ConsultaCadastrarViewModel viewModel);
        List<ConsultaIndexViewModel> ObterTodos();
    }
}