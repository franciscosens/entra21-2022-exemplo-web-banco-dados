using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Repositorios;
using Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoEntidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoViewModels;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.ResponsaveisContatos;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.Servicos;

public class ResponsavelContatoServico : IResponsavelContatoServico
{
    private readonly IResponsavelContatoRepositorio _responsavelContatoRepository;
    private readonly IResponsavelContatoMapeamentoEntidade _mapeamentoEntidade;
    private readonly IResponsavelContatoMapeamentoViewModel _mapeamentoViewModel;

    public ResponsavelContatoServico(
        IResponsavelContatoRepositorio responsavelContatoRepository,
        IResponsavelContatoMapeamentoEntidade mapeamentoEntidade, 
        IResponsavelContatoMapeamentoViewModel mapeamentoViewModel)
    {
        _responsavelContatoRepository = responsavelContatoRepository;
        _mapeamentoEntidade = mapeamentoEntidade;
        _mapeamentoViewModel = mapeamentoViewModel;
    }

    public ResponsavelContato Cadastrar(ResponsavelContatoCadastrarViewModel viewModel)
    {
        var responsavelContato = _mapeamentoEntidade.ConstruirCom(viewModel);

        return _responsavelContatoRepository.Cadastrar(responsavelContato);
    }

    public ResponsavelContato? Apagar(int id) => 
        _responsavelContatoRepository.Apagar(id);

    public ResponsavelContatoEditarViewModel ObterPorId(int contatoId)
    {
        var responsavelContato = _responsavelContatoRepository.ObterPorId(contatoId);

        var viewModel = _mapeamentoViewModel.ConstruirCom(responsavelContato);

        return viewModel;
    }

    public ResponsavelContato Editar(ResponsavelContatoEditarViewModel viewModel)
    {
        var responsavelContato = _responsavelContatoRepository.ObterPorId(viewModel.Id.GetValueOrDefault());

        if (responsavelContato == null)
            return null;

        responsavelContato = _mapeamentoEntidade.AtualizarCom(responsavelContato, viewModel);

        _responsavelContatoRepository.Editar(responsavelContato);

        return responsavelContato;
    }
}