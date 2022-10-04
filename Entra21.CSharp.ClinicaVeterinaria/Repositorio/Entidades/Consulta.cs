
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Enums;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades
{
    public class Consulta : EntidadeBase
    {
        public int PetId { get; set; }
        public int VeterinarioId { get; set; }


        public Pet Pet { get; set; }
        public Veterinario Veterinario { get; set; }
        public decimal Valor { get; set; }
        public ConsultaStatus Status { get; set; }
        public string Procedimento { get; set; }

        public DateTime DataHoraPrevista { get; set; }
        public DateTime? DataHoraFim { get; set; }
        public DateTime? DataHoraCancelamento { get; set; }
        public DateTime? DataHoraInicio { get; set; }

    }
}
