namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;

public class Exame : EntidadeBase
{
    public string Nome { get; set; }
    public string? Descricao { get; set; }
    public decimal Preco { get; set; }

    public IList<ConsultaExame> Consultas { get; set; }
}