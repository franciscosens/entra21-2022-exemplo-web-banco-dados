using Entra21.CSharp.ClinicaVeterinaria.Servico.Servicos;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Veterinarios;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.ClinicaVeterinaria.Aplicacao.Controllers
{
    [Route("/veterinario")]
    public class VeterinarioController : Controller
    {
        private readonly IVeterinarioServico _veterinarioServico;

        public VeterinarioController(IVeterinarioServico veterinarioServico)
        {
            _veterinarioServico = veterinarioServico;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("obterTodos")]
        public IActionResult ObterTodos([FromQuery] string pesquisa)
        {
            var veterinarios = _veterinarioServico.ObterTodos(pesquisa).ToList();

            return Ok(veterinarios);
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar([FromBody] VeterinarioCadastrarViewModel veterinarioCadastrarViewModel)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var veterinario = _veterinarioServico.Cadastrar(veterinarioCadastrarViewModel);

            return Ok(veterinario);
        }

        [HttpGet("obterPorId")]
        public IActionResult ObterPorId([FromQuery] int id)
        {
            var veterinario = _veterinarioServico.ObterPorId(id);

            if (veterinario == null)
                return NotFound();

            return Ok(veterinario);
        }

        [HttpPost("editar")]
        public IActionResult Editar([FromBody] VeterinarioEditarViewModel veterinarioEditarViewModel)
        {
            var alterou = _veterinarioServico.Editar(veterinarioEditarViewModel);

            if (!alterou)
                return NotFound();

            return Ok();
        }

        [HttpGet("apagar")]
        public IActionResult Apagar([FromQuery] int id)
        {
            var apagou = _veterinarioServico.Apagar(id);

            if (!apagou)
                return NotFound();

            return Ok();
        }
    }
}