using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Enums;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;

public class ResponsavelContato : EntidadeBase
{
    public ResponsavelContatoTipo Tipo { get; set; }
    public string Valor { get; set; }
    public int ResponsavelId { get; set; }
    // public string? Observacao { get; set; }
    
    public Responsavel Responsavel { get; set; }
}