using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Repositorios;

public interface IRepositoryBase<TEntity> where TEntity : EntidadeBase
{
    IList<TEntity> GetAll();
    TEntity? GetById(int id);
    TEntity Cadastrar(TEntity entity);
    TEntity Update(TEntity entity);
    TEntity? Delete(int id);
}