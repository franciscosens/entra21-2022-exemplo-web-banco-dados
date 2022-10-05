namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades
{
    public class ConsultaProcedimento : EntidadeBase
    {
        public int ProcedimentoId { get; set; }
        public int ConsultaId { get; set; }

        public Consulta Consulta { get; set; }
        public Procedimento Procedimento { get; set; }
    }
}