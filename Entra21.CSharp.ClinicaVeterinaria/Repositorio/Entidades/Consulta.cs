
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Enums;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades
{
    public class Consulta : EntidadeBase
    {
        public int PetId { get; set; }
        public int VeterinarioId { get; set; }

        public Pet Pet { get; set; }
        public Veterinario Veterinario { get; set; }
        public decimal ValorPrevisto { get; set; }
        public decimal? ValorEfetivo { get; set; }
        public ConsultaStatus Status { get; set; }
        public string? MotivoCancelamento { get; set; }
        public string Procedimento { get; set; }

        public DateTime DataHoraPrevista { get; set; }
        public DateTime? DataHoraFim { get; set; }
        public DateTime? DataHoraCancelamento { get; set; }
        public DateTime? DataHoraInicio { get; set; }

        public List<ConsultaProcedimento> ConsultaProcedimentos { get; set; }

        public void Cancelar(string motivo)
        {
            Status = ConsultaStatus.Cancelada;
            MotivoCancelamento = motivo;
            DataHoraInicio = DateTime.Now;
        }

        public void Iniciar()
        {
            Status = ConsultaStatus.EmAndamento;
            DataHoraInicio = DateTime.Now;
        }

        public void Finalizar(decimal valor)
        {
            Status = ConsultaStatus.Realizada;
            ValorEfetivo = valor;
            DataHoraFim = DateTime.Now;
        }

        public void AdicionarProcedimento(Procedimento procedimento)
        {
            var consutlaProcedimento = new ConsultaProcedimento
            {
                Procedimento = procedimento
            };
            
            ConsultaProcedimentos.Add(consutlaProcedimento);
        }
    }
}
