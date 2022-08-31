using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Repositorios;
using Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoEntidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoViewModels;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Consultas;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.Servicos;

public class ConsultaServico : IConsultaServico
{
    private readonly IConsultaRepositorio _consultaRepositorio;
    private readonly IConsultaMapeamentoEntidade _mapeamentoEntidade;
    private readonly IConsultaMapeamentoViewModel _mapeamentoViewModel;

    public ConsultaServico(
        IConsultaRepositorio consultaRepositorio, 
        IConsultaMapeamentoEntidade mapeamentoEntidade, 
        IConsultaMapeamentoViewModel mapeamentoViewModel)
    {
        _consultaRepositorio = consultaRepositorio;
        _mapeamentoEntidade = mapeamentoEntidade;
        _mapeamentoViewModel = mapeamentoViewModel;
    }

    public Consulta IniciarAgendamento(ConsultaIniciarAgendamentoViewModel viewModel)
    {
        var consulta = _mapeamentoEntidade.ConstruirCom(viewModel);

        _consultaRepositorio.Cadastrar(consulta);

        return consulta;
    }

    public IList<ConsultaIndexViewModel> ObterTodos()
    {
        var consultas = _consultaRepositorio.GetAll();

        return consultas
            .Select(x => _mapeamentoViewModel.ConstruirConsultaIndexViewModelCom(x))
            .ToList();
    }
}