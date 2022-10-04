using Entra21.CSharp.ClinicaVeterinaria.Servico.Servicos;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Consultas;
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

        [Route("cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar([FromBody]ConsultaCadastrarViewModel viewModel)
        {
            var consulta = _consultaServico.Cadastrar(viewModel);

            return Ok(consulta);
        }
    }
}
