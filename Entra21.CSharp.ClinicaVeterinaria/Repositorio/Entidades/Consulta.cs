using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Enums;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;

public class Consulta : EntidadeBase
{
    public int PetId { get; set; }
    public int VeterinarioId { get; set; }
    public ConsultaStatus Status { get; set; }
    public DateTime DataConsulta { get; set; }
    public decimal Total { get; set; }
    
    public Pet Pet { get; set; }
    public Veterinario Veterinario { get; set; }
    
    public IList<ConsultaExame> Exames { get; set; }
}