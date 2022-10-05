using Entra21.CSharp.ClinicaVeterinaria.Servico.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.ClinicaVeterinaria.Aplicacao.Controllers;

public class ProcedimentoController : Controller
{
    private readonly IProcedimentoServico _procedimentoServico;

    public ProcedimentoController(IProcedimentoServico procedimentoServico)
    {
        _procedimentoServico = procedimentoServico;
    }
    
    [HttpGet("obterTodos")]
    public IActionResult ObterTodos()
    {
        var procedimentoIndexViewModels = _procedimentoServico.ObterTodos();

        return Ok(procedimentoIndexViewModels);
    }
}