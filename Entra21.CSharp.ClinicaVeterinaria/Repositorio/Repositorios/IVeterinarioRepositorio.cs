using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Repositorios
{
    public interface IVeterinarioRepositorio
    {
        bool Apagar(int id);
        Veterinario Cadastrar(Veterinario veterinario);
        void Editar(Veterinario veterinario);
        Veterinario? ObterPodId(int id);
        IList<Veterinario> ObterTodos(string pesquisa);
    }
}