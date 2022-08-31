using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Exames;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoEntidades;

public interface IExameMapeamentoEntidade
{
    Exame ConstruirCom(ExameCadastrarViewModel viewModel);
    void AtualizarCom(Exame exame, ExameEditarViewModel viewModel);
}