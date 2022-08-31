using System.ComponentModel.DataAnnotations;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.ResponsaveisContatos;

public class ResponsavelContatoEditarViewModel : ResponsavelContatoBaseViewModel
{
    [Display(Name = nameof(Id))]
    [Required(ErrorMessage = "{0} deve ser preenchido")]
    public int? Id { get; set; }
}