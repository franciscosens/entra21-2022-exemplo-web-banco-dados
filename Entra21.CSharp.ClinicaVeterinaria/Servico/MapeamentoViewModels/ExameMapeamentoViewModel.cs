using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Exames;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoViewModels;

public class ExameMapeamentoViewModel : IExameMapeamentoViewModel
{
    public IList<ExameIndexViewModel> ConstruirCom(IList<Exame> exames)
    {
        var examesIndexViewModel = new List<ExameIndexViewModel>();
        
        foreach (var exame in exames)
        {
            examesIndexViewModel.Add(new ExameIndexViewModel
            {
                Id = exame.Id,
                Nome = exame.Nome,
                Preco = exame.Preco,
            });
        }

        return examesIndexViewModel;
    }

    public ExameDetalheViewModel ConstruirCom(Exame exame)
    {
        return new ExameDetalheViewModel
        {
            Id = exame.Id,
            Nome = exame.Nome,
            Preco = exame.Preco,
            Descricao = exame.Descricao
        };
    }

    public ExameCadastrarViewModel ConstruirExameCadastrarViewModelCom(Exame exame) =>
        new ExameCadastrarViewModel
        {
            Nome = exame.Nome,
            Preco = exame.Preco
        };

    public ExameEditarViewModel ConstruirExameEditarViewModelCom(Exame exame) =>
        new ExameEditarViewModel
        {
            Id = exame.Id,
            Nome = exame.Nome,
            Preco = exame.Preco
        };
}