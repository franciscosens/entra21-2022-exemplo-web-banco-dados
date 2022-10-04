using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Consultas
{
    public class ConsultaCadastrarViewModel
    {
        public DateTime DataHoraPrevista { get; set; }
        public int PetId { get; set; }
        public int VeterinarioId { get; set; }
        public decimal Valor { get; set; }
        public string Procedimento { get; set; }
    }
}
