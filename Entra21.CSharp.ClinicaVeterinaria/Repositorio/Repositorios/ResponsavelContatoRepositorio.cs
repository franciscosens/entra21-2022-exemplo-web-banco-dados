using Entra21.CSharp.ClinicaVeterinaria.Repositorio.BancoDados;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Repositorios;

public class ResponsavelContatoRepositorio : IResponsavelContatoRepositorio
{
    private readonly ClinicaVeterinariaContexto _contexto;

    public ResponsavelContatoRepositorio(ClinicaVeterinariaContexto contexto)
    {
        _contexto = contexto;
    }

    public ResponsavelContato Cadastrar(ResponsavelContato responsavelContato)
    {
        _contexto.ResponsavelContatos.Add(responsavelContato);
        _contexto.SaveChanges();

        return responsavelContato;
    }

    public ResponsavelContato? Apagar(int id)
    {
        var responsavelContato = _contexto.ResponsavelContatos
            .FirstOrDefault(x => x.Id == id);

        if (responsavelContato == null)
            return null;

        _contexto.ResponsavelContatos.Remove(responsavelContato);
        _contexto.SaveChanges();

        return responsavelContato;
    }

    public ResponsavelContato? ObterPorId(int contatoId) => 
        _contexto.ResponsavelContatos.FirstOrDefault(x => x.Id == contatoId);

    public void Editar(ResponsavelContato responsavelContato)
    {
        _contexto.ResponsavelContatos.Update(responsavelContato);
        _contexto.SaveChanges();
    }
}