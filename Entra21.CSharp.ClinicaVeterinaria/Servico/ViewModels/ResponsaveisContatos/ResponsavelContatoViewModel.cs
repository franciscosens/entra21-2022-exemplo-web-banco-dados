using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Enums;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.ResponsaveisContatos;

public class ResponsavelContatoViewModel
{
    public int Id { get; set; }
    public ResponsavelContatoTipo Tipo { get; set; }
    public string Valor { get; set; }
}