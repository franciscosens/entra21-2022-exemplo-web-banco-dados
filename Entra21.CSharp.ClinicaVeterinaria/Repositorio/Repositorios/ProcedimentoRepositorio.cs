using Entra21.CSharp.ClinicaVeterinaria.Repositorio.BancoDados;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Repositorios
{
    public class ProcedimentoRepositorio : RepositorioBase<Procedimento>, IProcedimentoRepositorio
    {
        public ProcedimentoRepositorio(ClinicaVeterinariaContexto contexto) : base(contexto)
        {
        }
    }
}