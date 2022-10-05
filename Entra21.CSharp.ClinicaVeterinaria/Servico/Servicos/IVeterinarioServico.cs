using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Veterinarios;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.Servicos
{
    public interface IVeterinarioServico
    {
        bool Apagar(int id);
        Veterinario Cadastrar(VeterinarioCadastrarViewModel viewModel);
        bool Editar(VeterinarioEditarViewModel viewModel);
        Veterinario? ObterPorId(int id);
        IList<Veterinario> ObterTodos(string pesquisa);
        IList<SelectViewModel> ObterTodosSelect2();
    }
}