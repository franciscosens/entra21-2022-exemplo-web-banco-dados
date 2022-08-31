using Entra21.CSharp.ClinicaVeterinaria.Servico.Servicos;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.ResponsaveisContatos;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.ClinicaVeterinaria.Aplicacao.Controllers;

[Route("responsavelContato")]
public class ResponsavelContatoController : Controller
{
    private readonly IResponsavelContatoServico _responsavelContatoService;

    public ResponsavelContatoController(IResponsavelContatoServico responsavelContatoService)
    {
        _responsavelContatoService = responsavelContatoService;
    }

    [HttpGet("cadastrar")]
    public IActionResult CadastrarModal([FromQuery] int responsavelId)
    {
        var viewModel = new ResponsavelContatoCadastrarViewModel
        {
            ResponsavelId = responsavelId
        };

        return PartialView(viewModel);
    }

    [HttpPost("cadastrar")]
    public IActionResult CadastrarModal([FromBody] ResponsavelContatoCadastrarViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return PartialView(viewModel);
        }

        var responsavelContato = _responsavelContatoService.Cadastrar(viewModel);

        return Created($"/responsavel/editar", new { id = responsavelContato.ResponsavelId });
    }

    [HttpGet("apagar")]
    public IActionResult Apagar([FromQuery] int id)
    {
        var responsavelContato = _responsavelContatoService.Apagar(id);

        if (responsavelContato == null)
            return NotFound();

        return RedirectToAction(
            nameof(ResponsavelController.Editar),
            "Responsavel",
            new
            {
                id = responsavelContato.ResponsavelId
            });
    }
    
    [HttpGet("editar")]
    public IActionResult EditarModal([FromQuery] int id)
    {
        var viewModel = _responsavelContatoService.ObterPorId(id);
        
        return PartialView(viewModel);
    }

    [HttpPost("editar")]
    public IActionResult EditarModal([FromBody] ResponsavelContatoEditarViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return PartialView(viewModel);
        }

        var responsavelContato = _responsavelContatoService.Editar(viewModel);

        return Created($"/responsavel/editar", new { id = responsavelContato.ResponsavelId });
    }
}