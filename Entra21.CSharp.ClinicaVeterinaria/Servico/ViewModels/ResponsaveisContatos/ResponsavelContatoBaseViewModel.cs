using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Enums;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.ResponsaveisContatos;

public abstract class ResponsavelContatoBaseViewModel : IValidatableObject
{
    public int ResponsavelId { get; set; }

    [Display(Name = nameof(Tipo))]
    [Required(ErrorMessage = "{0} deve ser preenchido")]
    public int? Tipo { get; set; }

    [Display(Name = nameof(Valor))]
    [Required(ErrorMessage = "{0} deve ser preenchido")]
    public string? Valor { get; set; }

    public string? Observacao { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Tipo.HasValue && Valor != null)
        {
            var tipo = Tipo.Value;

            if (tipo == (int)ResponsavelContatoTipo.Celular && NaoEhUmCelularValido())
            {
                yield return new ValidationResult(
                    "Valor deve conter um celular no formato (00) 90000-0000",
                    new[] { nameof(Valor) });
            }
            else if (tipo == (int)ResponsavelContatoTipo.Email && NaoEhUmEmailValido())
            {
                yield return new ValidationResult(
                    "Valor deve conter um e-mail válido",
                    new[] { nameof(Valor) });
            }
            else if (tipo == (int)ResponsavelContatoTipo.Telefone && NaoEhTTelefoneValido())
            {
                yield return new ValidationResult(
                    "Valor deve conter um telefone no formato (00) 0000-0000",
                    new[] { nameof(Valor) });
            }
        }
    }

    private bool NaoEhUmEmailValido() =>
        !Regex.IsMatch(Valor, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

    private bool NaoEhUmCelularValido() =>
        !Regex.IsMatch(Valor, @"^\([1-9]{2}\) (?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$");

    private bool NaoEhTTelefoneValido() =>
        !Regex.IsMatch(Valor, @"^\([1-9]{2}\) [0-9]{4}\-[0-9]{4}$");
}