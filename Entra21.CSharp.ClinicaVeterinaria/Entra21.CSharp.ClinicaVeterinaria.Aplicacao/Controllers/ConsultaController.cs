using Entra21.CSharp.ClinicaVeterinaria.Servico.Servicos;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Consultas;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.ConsultasProcedimentos;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.ClinicaVeterinaria.Aplicacao.Controllers
{
    [Route("consulta")]
    public class ConsultaController : Controller
    {
        private readonly IConsultaServico _consultaServico;

        public ConsultaController(IConsultaServico consultaServico)
        {
            _consultaServico = consultaServico;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar([FromBody]ConsultaCadastrarViewModel viewModel)
        {
            var consulta = _consultaServico.Cadastrar(viewModel);

            return Ok(consulta);
        }

        [HttpPost("iniciar")]
        public IActionResult Iniciar([FromBody]ConsultaIniciarViewModel viewModel)
        {
            _consultaServico.Iniciar(viewModel);

            return Ok();
        }

        [HttpPost("cancelar")]
        public IActionResult Cancelar([FromBody]ConsultaCancelarViewModel viewModel)
        {
            _consultaServico.Cancelar(viewModel);

            return Ok();
        }

        [HttpPost("cancelar")]
        public IActionResult Finalizar([FromBody]ConsultaFinalizarViewModel viewModel)
        {
            _consultaServico.Finalizar(viewModel);

            return Ok();
        }
        
        [HttpGet("obterTodos")]
        public IActionResult ObterTodos()
        {
            var consultaIndexViewModels = _consultaServico.ObterTodos();

            return Ok(consultaIndexViewModels);
        }
        
        [HttpPost("obterTodos")]
        public IActionResult AdicionarProcedimento([FromBody]ConsultaAdicionarProcedimentoViewModel viewModel)
        {
            _consultaServico.AdicionarProcedimento(viewModel);

            return Ok();
        }
    }
}
