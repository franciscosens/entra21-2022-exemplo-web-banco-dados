using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Repositorios
{
    public interface IRepositorioBase<TEntidade>
        where TEntidade : EntidadeBase
    {
        TEntidade Cadastrar(TEntidade entidade);
        void Editar(TEntidade entidade);
        void Apagar(int id);
        List<TEntidade> ObterTodos();
        TEntidade? ObterPorId(int id);
    }
}