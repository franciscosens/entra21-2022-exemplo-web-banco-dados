using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Repositorios;
using Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoEntidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoViewModels;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Responsaveis;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.Servicos;

public class ResponsavelServico : IResponsavelServico
{
    private readonly IResponsavelRepositorio _responsavelRepositorio;
    private readonly IResponsavelMapeamentoEntidade _mapeamentoEntidade;
    private readonly IResponsavelViewModelMapeamentoViewModels _mapeamentoViewModel;

    public ResponsavelServico(
        IResponsavelRepositorio responsavelRepositorio,
        IResponsavelMapeamentoEntidade mapeamentoEntidade, 
        IResponsavelViewModelMapeamentoViewModels mapeamentoViewModel)
    {
        _responsavelRepositorio = responsavelRepositorio;
        _mapeamentoEntidade = mapeamentoEntidade;
        _mapeamentoViewModel = mapeamentoViewModel;
    }

    public bool Apagar(int id)
    {
        return _responsavelRepositorio.Apagar(id);
    }

    public Responsavel Cadastrar(ResponsavelCadastrarViewModel viewModel)
    {
        var responsavel = _mapeamentoEntidade.ConstruirCom(viewModel);
        
        _responsavelRepositorio.Cadastrar(responsavel);

        return responsavel;
    }

    public bool Editar(ResponsavelEditarViewModel viewModel)
    {
        var responsavel = _responsavelRepositorio.ObterPorId(viewModel.Id);

        if (responsavel == null)
            return false;

        responsavel = _mapeamentoEntidade.AtualizarCampos(responsavel, viewModel);
        
        _responsavelRepositorio.Editar(responsavel);

        return true;
    }

    public ResponsavelEditarViewModel? ObterPorId(int id)
    {
        var responsavel = _responsavelRepositorio.ObterPorId(id);

        if (responsavel == null)
            return null;

        var viewModel = _mapeamentoViewModel.ConstruirCom(responsavel);

        return viewModel;
    }

    public IList<Responsavel> ObterTodos() => 
        _responsavelRepositorio.ObterTodos();

    public IList<SelectViewModel> ObterTodosSelect2()
    {
        var pets = _responsavelRepositorio.ObterTodos();

        var selectViewModels = pets
            .Select(x => new SelectViewModel
            {
                Id = x.Id,
                Text = x.NomeCompleto
            })
            .ToList();

        return selectViewModels;
    }
}