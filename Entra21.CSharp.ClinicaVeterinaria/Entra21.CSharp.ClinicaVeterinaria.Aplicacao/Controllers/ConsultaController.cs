using Entra21.CSharp.ClinicaVeterinaria.Servico.Servicos;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Consultas;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.ClinicaVeterinaria.Aplicacao.Controllers;

[Route("consulta")]
public class ConsultaController : Controller
{
    private readonly IConsultaServico _consultaServico;

    public ConsultaController(IConsultaServico consultaServico)
    {
        _consultaServico = consultaServico;
    }

    [HttpGet]
    public IActionResult Index() =>
        View();

    [HttpGet("obterTodos")]
    public IActionResult ObterTodos()
    {
        var pets = _consultaServico.ObterTodos();

        return Ok(pets);
    }

    [HttpPost("iniciaragendamento")]
    public IActionResult IniciarAgendamento([FromBody] ConsultaIniciarAgendamentoViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var consulta = _consultaServico.IniciarAgendamento(viewModel);

        return Ok(consulta);
    }
}