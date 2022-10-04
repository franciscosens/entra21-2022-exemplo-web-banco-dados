using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Consultas
{
    public class ConsultaIndexViewModel
    {
        public string Veterinario { get; set; }
        public string Responsavel { get; set; }
        public string Pet { get; set; }
        public int Status { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataHoraPrevista { get; set; }
    }
}
