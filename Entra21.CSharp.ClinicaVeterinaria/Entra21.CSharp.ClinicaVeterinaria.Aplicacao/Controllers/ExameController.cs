using Entra21.CSharp.ClinicaVeterinaria.Servico.Servicos;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Exames;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.ClinicaVeterinaria.Aplicacao.Controllers;

[Route("exame")]
public class ExameController : Controller
{
    private readonly IExameServico _exameServico;
    
    public ExameController(IExameServico exameServico)
    {
        _exameServico = exameServico;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("obterTodos")]
    public IActionResult ObterTodos()
    {
        var exames = _exameServico.ObterTodos();

        return Ok(exames);
    }

    [HttpGet("obterPorId")]
    public IActionResult ObterPorId([FromQuery] int id)
    {
        var exames = _exameServico.ObterPorId(id);

        return Ok(exames);
    }

    [HttpPost("cadastrar")]
    public IActionResult Cadastrar([FromBody]ExameCadastrarViewModel exameCadastrarViewModel)
    {
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var exame = _exameServico.Cadastrar(exameCadastrarViewModel);

        return Ok(exame);
    }

    [HttpPost("editar")]
    public IActionResult Editar([FromBody]ExameEditarViewModel exameEditarViewModel)
    {
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var atualizou = _exameServico.Editar(exameEditarViewModel);
        
        return Ok(new {status= atualizou});
    }


    [HttpGet("apagar")]
    public IActionResult Apagar([FromQuery] int id)
    {
        var apagou = _exameServico.Apagar(id);

        if (!apagou)
            return NotFound();

        return Ok();
    }
}