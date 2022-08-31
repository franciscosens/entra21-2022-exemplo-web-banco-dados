using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Pets;

public class PetViewModel
{
    [Display(Name = nameof(Nome))]
    [Required(ErrorMessage = "{0} deve ser preenchido")]
    [MinLength(4, ErrorMessage = "{0} deve conter no mínimo {1} caracteres")]
    [MaxLength(50, ErrorMessage = "{0} deve conter no máximo {1} caracteres")]
    public string Nome { get; set; }
    
    [Display(Name = nameof(Peso))]
    [Required(ErrorMessage = "{0} deve ser preenchido")]
    [Range(0.00, 120.00, ErrorMessage = "{0} deve conter no mínimo {1} e no máximo {2}")]
    public decimal? Peso { get; set; }
    
    [Display(Name = nameof(Altura))]
    [Required(ErrorMessage = "{0} deve ser preenchida")]
    [Range(0.00, 1.60, ErrorMessage = "{0} deve conter no mínimo {1} e no máximo {2}")]
    public decimal? Altura { get; set; }
    
    [Display(Name = nameof(Idade))]
    [Required(ErrorMessage = "{0} deve ser preenchida")]
    public byte? Idade { get; set; }
    
    public byte Genero { get; set; }
    
    [Display(Name = "Responsável")]
    [Required(ErrorMessage = "{0} deve ser preenchido")]
    public int? ResponsavelId { get; set; }
    
    [Display(Name = "Raça")]
    [Required(ErrorMessage = "{0} deve ser preenchido")]
    public int? RacaId { get; set; }
    
    public IFormFile? Arquivo { get; set; }
}