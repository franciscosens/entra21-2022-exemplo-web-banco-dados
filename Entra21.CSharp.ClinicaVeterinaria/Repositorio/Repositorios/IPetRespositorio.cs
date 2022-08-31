using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Repositorios;

public interface IPetRepositorio
{
    bool Apagar(int id);
    Pet Cadastrar(Pet pet);
    void Editar(Pet pet);
    Pet? ObterPodId(int id);
    IList<Pet> ObterTodos();
    IList<Pet> ObterTodosPorResponsavelId(int responsavelId);
}