namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;

public class ConsultaExame : EntidadeBase
{
    public decimal Preco { get; set; }
    public int ConsultaId { get; set; }
    public int ExameId { get; set; }
    
    public Consulta Consulta { get; set; }
    public Exame Exame { get; set; }
}