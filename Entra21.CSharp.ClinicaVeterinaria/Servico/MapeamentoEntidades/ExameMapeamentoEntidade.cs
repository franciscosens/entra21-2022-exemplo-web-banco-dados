using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Exames;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoEntidades;

public class ExameMapeamentoEntidade : IExameMapeamentoEntidade
{
    public Exame ConstruirCom(ExameCadastrarViewModel viewModel) =>
        new Exame
        {
            Nome = viewModel.Nome,
            Descricao = viewModel.Descricao,
            Preco = viewModel.Preco.GetValueOrDefault()
        };

    public void AtualizarCom(Exame exame, ExameEditarViewModel viewModel)
    {
        exame.Nome = viewModel.Nome;
        exame.Descricao = viewModel.Descricao;
        exame.Preco = viewModel.Preco.GetValueOrDefault();
    }
}