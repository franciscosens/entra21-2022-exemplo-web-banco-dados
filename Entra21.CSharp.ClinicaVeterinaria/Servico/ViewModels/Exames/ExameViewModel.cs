using System.ComponentModel.DataAnnotations;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Exames;

public class ExameViewModel
{
    [Display(Name = nameof(Nome))]
    [Required(ErrorMessage = "{0} deve ser preenchido")]
    [MinLength(4, ErrorMessage = "{0} deve conter no mínimo {1} caracteres")]
    [MaxLength(50, ErrorMessage = "{0} deve conter no máximo {1} caracteres")]
    public string? Nome { get; set; }
    
    [Display(Name = "Preço")]
    [Required(ErrorMessage = "{0} deve ser preenchido")]
    [Range(0.00, 9_999_999.00, ErrorMessage = "{0} deve conter no mínimo {1} e no máximo {2}")]
    public decimal? Preco { get; set; }
    public string? Descricao { get; set; }
}