using Entra21.CSharp.ClinicaVeterinaria.Servico.Servicos;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Responsaveis;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.ClinicaVeterinaria.Aplicacao.Controllers;

[Route("responsavel")]
public class ResponsavelController : Controller
{
    private readonly IResponsavelServico _responsavelServico;

    public ResponsavelController(IResponsavelServico responsavelServico)
    {
        _responsavelServico = responsavelServico;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("obterTodos")]
    public IActionResult ObterTodos()
    {
        var responsaveis = _responsavelServico.ObterTodos();

        return Ok(responsaveis);
    }

    [HttpGet("cadastrar")]
    public IActionResult Cadastrar()
    {
        var viewModel = new ResponsavelCadastrarViewModel();

        return View(viewModel);
    }

    [HttpPost("cadastrar")]
    public IActionResult Cadastrar(ResponsavelCadastrarViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        var responsavel = _responsavelServico.Cadastrar(viewModel);

        return RedirectToAction(nameof(Editar), new { id = responsavel.Id });
    }

    [HttpGet("editar")]
    public IActionResult Editar([FromQuery] int id)
    {
        var viewModel = _responsavelServico.ObterPorId(id);

        return View(viewModel);
    }

    [HttpPost("editar")]
    public IActionResult Editar(ResponsavelEditarViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        var responsavel = _responsavelServico.Editar(viewModel);

        return RedirectToAction(nameof(Editar), new { id = viewModel.Id });
    }

    [HttpGet("obterTodosSelect2")]
    public IActionResult ObterTodosSelect2()
    {
        var selectViewModel = _responsavelServico.ObterTodosSelect2();

        return Ok(selectViewModel);
    }

    [HttpGet("apagar")]
    public IActionResult Apagar([FromQuery] int id)
    {
        _responsavelServico.Apagar(id);

        return RedirectToAction(nameof(Index));
    }
}