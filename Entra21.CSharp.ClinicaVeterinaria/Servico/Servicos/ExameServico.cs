using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Repositorios;
using Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoEntidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoViewModels;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Exames;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.Servicos;

public class ExameServico : IExameServico 
{
    private readonly IExameMapeamentoViewModel _mapeamentoViewModel;
    private readonly IExameRepositorio _exameRepositorio;
    private readonly IExameMapeamentoEntidade _mapeamentoEntidade;

    public ExameServico(
        IExameRepositorio exameRepositorio, 
        IExameMapeamentoViewModel mapeamentoViewModel, 
        IExameMapeamentoEntidade mapeamentoEntidade)
    {
        _exameRepositorio = exameRepositorio;
        _mapeamentoViewModel = mapeamentoViewModel;
        _mapeamentoEntidade = mapeamentoEntidade;
    }
    
    public IList<ExameIndexViewModel> ObterTodos()
    {
        var exames = _exameRepositorio.GetAll();

        return _mapeamentoViewModel.ConstruirCom(exames);
    }

    public ExameDetalheViewModel ObterPorId(int id)
    {
        var exame = _exameRepositorio.GetById(id);

        if (exame == null)
            throw new Exception();

        return _mapeamentoViewModel.ConstruirCom(exame);
    }

    public Exame Cadastrar(ExameCadastrarViewModel viewModel)
    {
        var exame = _mapeamentoEntidade.ConstruirCom(viewModel);

        exame = _exameRepositorio.Cadastrar(exame);

        return exame;
    }

    public bool Editar(ExameEditarViewModel viewModel)
    {
        var exame = _exameRepositorio.GetById(viewModel.Id);

        if (exame == null)
            return false;

        _mapeamentoEntidade.AtualizarCom(exame, viewModel);

        _exameRepositorio.Update(exame);

        return true;
    }

    public bool Apagar(int id)
    {
        var exame = _exameRepositorio.Delete(id);

        return exame != null;
    }
}