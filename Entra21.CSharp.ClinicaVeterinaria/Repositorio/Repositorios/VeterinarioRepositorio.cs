using Entra21.CSharp.ClinicaVeterinaria.Repositorio.BancoDados;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Repositorios
{
    public class VeterinarioRepositorio : IVeterinarioRepositorio
    {
        private readonly ClinicaVeterinariaContexto _contexto;

        public VeterinarioRepositorio(ClinicaVeterinariaContexto contexto)
        {
            _contexto = contexto;
        }

        public bool Apagar(int id)
        {
            var veterinario = _contexto.Veterinarios
                .FirstOrDefault(x => x.Id == id);

            if (veterinario == null)
                return false;

            _contexto.Veterinarios.Remove(veterinario);
            _contexto.SaveChanges();

            return true;
        }

        public Veterinario Cadastrar(Veterinario veterinario)
        {
            _contexto.Veterinarios.Add(veterinario);
            _contexto.SaveChanges();

            return veterinario;
        }

        public void Editar(Veterinario veterinario)
        {
            _contexto.Veterinarios.Update(veterinario);
            _contexto.SaveChanges();
        }

        public Veterinario? ObterPodId(int id) =>
            _contexto.Veterinarios
                .FirstOrDefault(x => x.Id == id);

        public IList<Veterinario> ObterTodos(string pesquisa)
        {
            var query = _contexto.Veterinarios.AsQueryable();
            
            if (!string.IsNullOrEmpty(pesquisa))
                // Nome com LIKE ou CRMV exatamente 
                query = query.Where(x => x.Nome.Contains(pesquisa) || x.Crmv == pesquisa);

            return query.ToList();
        }
    }
}