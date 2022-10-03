using System.ComponentModel.DataAnnotations;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Enums;

public enum ResponsavelContatoTipo
{
    [Display(Name = "E-mail")]
    Email,
    [Display(Name = "Telefone")]
    Telefone,
    [Display(Name = "Celular")]
    Celular
}