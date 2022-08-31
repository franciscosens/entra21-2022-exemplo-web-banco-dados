using System.ComponentModel.DataAnnotations;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.ResponsaveisContatos;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Responsaveis;

public class ResponsavelEditarViewModel : ResponsavelViewModel
{
    [Display(Name = "Id")]
    [Required(ErrorMessage = "{0} deve ser preenchido")]
    public int Id { get; set; }

    public IList<ResponsavelContatoViewModel> Contatos { get; set; } = new List<ResponsavelContatoViewModel>();
}