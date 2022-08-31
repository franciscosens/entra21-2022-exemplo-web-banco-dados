using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Exames;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoViewModels;

public interface IExameMapeamentoViewModel
{
    IList<ExameIndexViewModel> ConstruirCom(IList<Exame> exames);
    ExameDetalheViewModel ConstruirCom(Exame exame);
    ExameCadastrarViewModel ConstruirExameCadastrarViewModelCom(Exame exame);
    ExameEditarViewModel ConstruirExameEditarViewModelCom(Exame exame);
}