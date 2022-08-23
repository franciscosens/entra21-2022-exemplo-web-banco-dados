using System.ComponentModel.DataAnnotations;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Veterinarios
{
    public class VeterinarioCadastrarViewModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [MinLength(3, ErrorMessage = "{0} deve conter no mínimo {1}")]
        [MaxLength(30, ErrorMessage = "{0} deve conter no máximo {1}")]
        public string Nome { get; set; }

        [Display(Name = "CRMV")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [StringLength(7, ErrorMessage = "{0} deve conter {1} caracteres")]
        public string Crmv { get; set; }
    }
}
