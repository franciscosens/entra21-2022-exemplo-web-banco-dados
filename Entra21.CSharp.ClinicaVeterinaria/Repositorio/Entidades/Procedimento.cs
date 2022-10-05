namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades
{
    public class Procedimento : EntidadeBase
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        
        public List<ConsultaProcedimento> ConsultaProcedimentos { get; set; }
    }
}