using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Enums;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;

public class Endereco : EntidadeBase
{
    public UnidadeFederativa UnidadeFederativa { get; set; }
    public string Cidade { get; set; }
    public string Bairro { get; set; }
    public string Cep { get; set; }
    public string Localidade { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
}