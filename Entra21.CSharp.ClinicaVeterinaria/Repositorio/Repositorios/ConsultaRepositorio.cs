using Entra21.CSharp.ClinicaVeterinaria.Repositorio.BancoDados;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Repositorios;

public class ConsultaRepositorio : RepositoryBase<Consulta>, IConsultaRepositorio
{
    public ConsultaRepositorio(ClinicaVeterinariaContexto contexto) : base(contexto)
    {
    }
}