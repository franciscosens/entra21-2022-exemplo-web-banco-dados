using System.ComponentModel.DataAnnotations;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Veterinarios;

public class VeterinarioEditarViewModel
{
    public int Id { get; set; }
    [Required]
    public int? Idade { get; set; }
    [Required]
    public decimal? Salario { get; set; }
}