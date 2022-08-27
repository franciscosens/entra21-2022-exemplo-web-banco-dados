using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Repositorios;

public interface IResponsavelContatoRepositorio
{
    ResponsavelContato Cadastrar(ResponsavelContato responsavelContato);
    ResponsavelContato? Apagar(int id);
    ResponsavelContato? ObterPorId(int contatoId);
    void Editar(ResponsavelContato responsavelContato);
}