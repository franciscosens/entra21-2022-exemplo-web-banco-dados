using Entra21.CSharp.ClinicaVeterinaria.Repositorio.BancoDados;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Repositorios;

public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
    where TEntity : EntidadeBase
{
    private readonly ClinicaVeterinariaContexto _context;
    private readonly DbSet<TEntity> _dbSet;

    public RepositoryBase(ClinicaVeterinariaContexto contexto)
    {
        _context = contexto;
        _dbSet = contexto.Set<TEntity>();
    }

    public IList<TEntity> GetAll() =>
        _dbSet.ToList();

    public TEntity? GetById(int id)
    {
        return _dbSet.FirstOrDefault(x => x.Id == id);
    }

    public TEntity Cadastrar(TEntity entity)
    {
        _dbSet.Add(entity);
        _context.SaveChanges();

        return entity;
    }

    public TEntity Update(TEntity entity)
    {
        _dbSet.Update(entity);
        _context.SaveChanges();

        return entity;
    }

    public TEntity? Delete(int id)
    {
        var entity = GetById(id);

        if (entity == null)
            return null;


        _dbSet.Remove(entity);
        _context.SaveChanges();

        return entity;
    }
}