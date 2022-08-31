using Entra21.CSharp.ClinicaVeterinaria.Repositorio.BancoDados;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Repositorios;

public class PetRepositorio : IPetRepositorio
{
    private readonly ClinicaVeterinariaContexto _contexto;

    public PetRepositorio(ClinicaVeterinariaContexto contexto)
    {
        _contexto = contexto;
    }

    public bool Apagar(int id)
    {
        var pet = _contexto.Pets
            .FirstOrDefault(x => x.Id == id);

        if (pet == null)
            return false;

        _contexto.Pets.Remove(pet);
        _contexto.SaveChanges();

        return true;
    }

    public Pet Cadastrar(Pet pet)
    {
        _contexto.Pets.Add(pet);
        _contexto.SaveChanges();

        return pet;
    }

    public void Editar(Pet pet)
    {
        _contexto.Pets.Update(pet);
        _contexto.SaveChanges();
    }

    public Pet? ObterPodId(int id) => 
        _contexto.Pets
            // INNER JOIN com a tabela de Responsaveis
            .Include(x => x.Responsavel) 
            .Include(x => x.Raca)
            .FirstOrDefault(x => x.Id == id);

    public IList<Pet> ObterTodos() => 
        _contexto.Pets
        // INNER JOIN com a tabela de Responsaveis
            .Include(x => x.Responsavel) 
            .Include(x => x.Raca)
            .ToList();

    public IList<Pet> ObterTodosPorResponsavelId(int responsavelId) =>
        _contexto.Pets
            .Where(x => x.ResponsavelId == responsavelId)
            .ToList();
}