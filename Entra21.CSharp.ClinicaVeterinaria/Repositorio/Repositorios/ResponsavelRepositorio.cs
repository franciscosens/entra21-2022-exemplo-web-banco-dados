using Entra21.CSharp.ClinicaVeterinaria.Repositorio.BancoDados;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Repositorios;

public class ResponsavelRepositorio : IResponsavelRepositorio
{
    private readonly ClinicaVeterinariaContexto _contexto;

    public ResponsavelRepositorio(ClinicaVeterinariaContexto contexto)
    {
        _contexto = contexto;
    }

    public bool Apagar(int id)
    {
        var responsavel = _contexto.Responsaveis
            .FirstOrDefault(x => x.Id == id);

        if (responsavel == null)
            return false;

        _contexto.Responsaveis.Remove(responsavel);
        _contexto.SaveChanges();

        return true;
    }

    public Responsavel Cadastrar(Responsavel responsavel)
    {
        _contexto.Responsaveis.Add(responsavel);
        _contexto.SaveChanges();

        return responsavel;
    }

    public void Editar(Responsavel responsavel)
    {
        _contexto.Responsaveis.Update(responsavel);
        _contexto.SaveChanges();
    }

    public Responsavel? ObterPorId(int id) =>
        _contexto.Responsaveis
            .Include(x => x.Contatos)
            .FirstOrDefault(x => x.Id == id);

    public IList<Responsavel> ObterTodos() => 
        _contexto.Responsaveis.ToList();
}