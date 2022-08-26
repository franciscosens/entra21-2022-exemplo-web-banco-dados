using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Repositorios;

public interface IResponsavelRepositorio
{
    bool Apagar(int id);
    Responsavel Cadastrar(Responsavel responsavel);
    void Editar(Responsavel responsavel);
    Responsavel? ObterPorId(int id);
    IList<Responsavel> ObterTodos();
}