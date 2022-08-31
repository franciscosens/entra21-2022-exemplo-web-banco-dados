using Entra21.CSharp.ClinicaVeterinaria.Repositorio.BancoDados;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Repositorios;

public class ExameRepositorio : RepositoryBase<Exame>, IExameRepositorio
{
    public ExameRepositorio(ClinicaVeterinariaContexto contexto) : base(contexto)
    {
    }
}