using Entra21.CSharp.ClinicaVeterinaria.Repositorio.BancoDados;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Enuns;
using Entra21.CSharp.ClinicaVeterinaria.Servico;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.ClinicaVeterinaria.Aplicacao.Controllers
{
    // Dois pontos mais pra frente é sobre Herença
    public class RacaController : Controller
    {
        private readonly IRacaServico _racaServico;

        /* Construtor: objetivo - construir o objeto de RacaController,
         com o mínimo necessário para o funcionamento correto */

        public RacaController(ClinicaVeterinariaContexto contexto)
        {
            _racaServico = new RacaServico(contexto);
        }

        /// <summary>
        /// Endpoint que permite lista todas as raças
        /// </summary>
        /// <returns>Retorna a página html com as raças</returns>
        [HttpGet("/raca")]
        public IActionResult ObterTodos()
        {
            var racas = _racaServico.ObterTodos();

            // Passar informação do C# para o HTML
            ViewBag.Racas = racas;

            return View("Index");
        }

        [HttpGet("/raca/cadastrar")]
        public IActionResult Cadastrar()
        {
            var especies = ObterEspecies();

            ViewBag.Especies = ObterEspecies();

            var racaCadastrarViewModel = new RacaCadastrarViewModel();

            return View(racaCadastrarViewModel);
        }

        [HttpPost("/raca/Cadastrar")]
        public IActionResult Cadastrar(
            [FromForm] RacaCadastrarViewModel racaCadastrarViewModel)
        {
            // Valida o parâmetro recebido na Action se é inválido
            //if (ModelState.IsValid == false)
            if (!ModelState.IsValid)
            {
                ViewBag.Especies = ObterEspecies();

                return View(racaCadastrarViewModel);
            }

            _racaServico.Cadastrar(racaCadastrarViewModel);

            return RedirectToAction("Index");
        }

        [HttpGet("/raca/apagar")]
        // http://local:host:porta/raca/apagar?id=4
        public IActionResult Apagar([FromQuery] int id)
        {
            _racaServico.Apagar(id);

            return RedirectToAction("Index");
        }

        [HttpGet("raca/editar")]
        public IActionResult Editar([FromQuery] int id)
        {
            var raca = _racaServico.ObterPorId(id);
            var especies = ObterEspecies();

            ViewBag.Raca = raca;
            ViewBag.Especies = especies;

            return View("Editar");
        }

        [HttpPost("/raca/editar")]
        public IActionResult Editar(
            [FromForm] RacaEditarViewModel racaEditarViewModel)
        {
            _racaServico.Editar(racaEditarViewModel);

            return RedirectToAction("Index");
        }

        private List<string> ObterEspecies()
        {
            return Enum.GetNames<Especie>()
                            .OrderBy(x => x)
                            .ToList();
        }
    }
}
