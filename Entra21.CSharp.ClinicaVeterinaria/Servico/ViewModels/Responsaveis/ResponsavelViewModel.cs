using System.ComponentModel.DataAnnotations;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Responsaveis;

public abstract class ResponsavelViewModel
{
    [Display(Name = "Nome Completo")]
    [Required(ErrorMessage = "{0} deve ser preenchido")]
    [MinLength(4, ErrorMessage = "{0} deve conter no mínimo {1} caracteres")]
    [MaxLength(200, ErrorMessage = "{0} deve conter no máximo {1} caracteres")]
    public string NomeCompleto { get; set; }
    
    [Display(Name = "Idade")]
    [Required(ErrorMessage = "{0} deve ser preenchida")]
    [Range(0, byte.MaxValue, ErrorMessage = "{0} deve conter no mínimo {1} e no máximo {2}")]
    public byte? Idade { get; set; }
    
    [Display(Name = "CPF")]
    [Required(ErrorMessage = "{0} deve ser preenchido")]
    [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "{0} deve ser preenchido no formato '000.000.000-00'")]
    public string Cpf { get; set; }
}