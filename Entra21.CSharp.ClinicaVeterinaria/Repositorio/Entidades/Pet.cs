using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Enums;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;

public class Pet : EntidadeBase
{
    public string Nome { get; set; }
    public int Idade { get; set; }
    public decimal Peso { get; set; }
    public decimal Altura { get; set; }
    public PetGenero Genero { get; set; }
    public string? CaminhoArquivo { get; set; }

    public int RacaId { get; set; }
    public Raca Raca { get; set; }

    public int ResponsavelId { get; set; }
    public Responsavel Responsavel { get; set; }

    public List<Consulta> Consultas { get; set; }
}