using System.ComponentModel.DataAnnotations;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.Attributes;

public class DateGreaterThanOrEqualToToday : ValidationAttribute
{
    public override string FormatErrorMessage(string name) => 
        $"{name} deve ser maior ou igual a hoje";

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var dateValue = value as DateTime? ?? DateTime.Today;
        
        return dateValue.Date >= DateTime.Today.Date 
            ? new ValidationResult(FormatErrorMessage(validationContext.DisplayName)) 
            : ValidationResult.Success;
    }
}