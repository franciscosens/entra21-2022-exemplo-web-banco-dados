using Entra21.CSharp.ClinicaVeterinaria.Servico.Servicos;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Pets;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.ClinicaVeterinaria.Aplicacao.Controllers;

[Route("pet")]
public class PetController : Controller
{
    private readonly IPetServico _petServico;
    private readonly IWebHostEnvironment _webHostEnvironment;
    
    public PetController(IPetServico petServico, 
        IWebHostEnvironment webHostEnvironment)
    {
        _petServico = petServico;
        _webHostEnvironment = webHostEnvironment;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("obterTodos")]
    public IActionResult ObterTodos()
    {
        var pets = _petServico.ObterTodos();

        return Ok(pets);
    }

    [HttpPost("cadastrar")]
    public IActionResult Cadastrar([FromForm]PetCadastrarViewModel petCadastrarViewModel)
    {
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var pet = _petServico.Cadastrar(petCadastrarViewModel, _webHostEnvironment.WebRootPath);

        return Ok(pet);
    }

    [HttpGet("apagar")]
    public IActionResult Apagar([FromQuery] int id)
    {
        var apagou = _petServico.Apagar(id);

        if (!apagou)
            return NotFound();

        return Ok();
    }
}