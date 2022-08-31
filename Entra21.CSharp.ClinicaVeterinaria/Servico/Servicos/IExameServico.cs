using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Exames;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.Servicos;

public interface IExameServico
{
    IList<ExameIndexViewModel> ObterTodos();
    ExameDetalheViewModel ObterPorId(int id);
    Exame Cadastrar(ExameCadastrarViewModel viewModel);
    bool Editar(ExameEditarViewModel viewModel);
    bool Apagar(int id);
    
}