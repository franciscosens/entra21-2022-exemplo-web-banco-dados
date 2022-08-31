namespace Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Consultas;

public class ConsultaIndexViewModel
{
    public int Id { get; set; }
    public string Veterinario { get; set; }
    public string Pet { get; set; }
    public string Responsavel { get; set; }
    public DateTime DataConsulta { get; set; }
}