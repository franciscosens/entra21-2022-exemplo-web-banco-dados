namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;

public class Responsavel : EntidadeBase
{
    public string NomeCompleto { get; set; }
    public byte Idade { get; set; }
    public string Cpf { get; set; }
    
    public IList<ResponsavelContato> Contatos { get; set; }
    public IList<Pet> Pets { get; set; }
}