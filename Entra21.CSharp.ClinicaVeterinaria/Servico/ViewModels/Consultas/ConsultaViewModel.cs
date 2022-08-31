using System.ComponentModel.DataAnnotations;
using Entra21.CSharp.ClinicaVeterinaria.Servico.Attributes;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Consultas;

public class ConsultaViewModel
{
    [Display(Name="Veterinário")]
    [Required(ErrorMessage = "{0} deve ser escolhido")]
    public int? VeterinarioId { get; set; }
    
    [Display(Name="PET")]
    [Required(ErrorMessage = "{0} deve ser escolhido")]
    public int? PetId { get; set; }
    
    [Display(Name="Data da Consulta")]
    [Required(ErrorMessage = "{0} deve ser escolhida")]
    [DateGreaterThanOrEqualToToday]
    public DateTime? DataConsulta { get; set; }
}