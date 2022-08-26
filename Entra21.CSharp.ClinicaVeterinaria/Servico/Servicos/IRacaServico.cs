using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Racas;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.Servicos
{
    public interface IRacaServico
    {
        void Cadastrar(RacaCadastrarViewModel racaCadastrarViewModel);
        List<Raca> ObterTodos();
        void Editar(RacaEditarViewModel racaEditarViewModel);
        void Apagar(int id);
        Raca ObterPorId(int id);
        IList<SelectViewModel> ObterTodosSelect2();
    }
}