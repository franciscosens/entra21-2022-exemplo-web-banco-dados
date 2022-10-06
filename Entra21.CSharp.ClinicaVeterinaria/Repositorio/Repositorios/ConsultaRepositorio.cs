using Entra21.CSharp.ClinicaVeterinaria.Repositorio.BancoDados;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Repositorios
{
    public class ConsultaRepositorio
        : RepositorioBase<Consulta>,
        IConsultaRepositorio
    {
        public ConsultaRepositorio(ClinicaVeterinariaContexto contexto) : base(contexto)
        {
        }

        public override List<Consulta> ObterTodos()
        {
            return _dbSet
                .Include(x => x.Pet)
                .ThenInclude(x => x.Raca)
                .Include(x => x.Veterinario)
                .ToList();
        }
    }
}
