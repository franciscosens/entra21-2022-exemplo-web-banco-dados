using Entra21.CSharp.ClinicaVeterinaria.Repositorio.BancoDados;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Repositorios
{
    // TEntidade é a utilização de Generics
    public class RepositorioBase<TEntidade> : IRepositorioBase<TEntidade>
        where TEntidade : EntidadeBase
    {
        protected readonly ClinicaVeterinariaContexto _contexto;
        protected readonly DbSet<TEntidade> _dbSet;

        public RepositorioBase(ClinicaVeterinariaContexto contexto)
        {
            _contexto = contexto;
            _dbSet = _contexto.Set<TEntidade>();
        }
        
        public virtual void Apagar(int id)
        {
            var entidade = _dbSet.FirstOrDefault(x => x.Id == id);

            if (entidade == null)
                return;

            _dbSet.Remove(entidade);
            _contexto.SaveChanges();
        }

        public virtual TEntidade Cadastrar(TEntidade entidade)
        {
            _dbSet.Add(entidade);
            _contexto.SaveChanges();
            return entidade;
        }

        public virtual void Editar(TEntidade entidade)
        {
            _dbSet.Update(entidade);
            _contexto.SaveChanges();
        }

        public virtual TEntidade? ObterPorId(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public virtual List<TEntidade> ObterTodos()
        {
            return _dbSet.ToList();
        }
    }
}
