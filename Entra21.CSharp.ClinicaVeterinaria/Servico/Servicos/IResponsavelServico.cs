using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Responsaveis;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.Servicos;

public interface IResponsavelServico
{
    bool Apagar(int id);
    Responsavel Cadastrar(ResponsavelCadastrarViewModel viewModel);
    bool Editar(ResponsavelEditarViewModel viewModel);
    ResponsavelEditarViewModel? ObterPorId(int id);
    IList<Responsavel> ObterTodos();
    IList<SelectViewModel> ObterTodosSelect2();
}