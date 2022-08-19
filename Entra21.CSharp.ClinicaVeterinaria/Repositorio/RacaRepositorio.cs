using Entra21.CSharp.ClinicaVeterinaria.Repositorio.BancoDados;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio
{
    public class RacaRepositorio : IRacaRepositorio
    {
        // Essa linha aqui que permite fazer as coisas tudo no banco de forma mais simples
        private readonly ClinicaVeterinariaContexto _contexto;

        public RacaRepositorio(ClinicaVeterinariaContexto contexto)
        {
            _contexto = contexto;
        }

        public void Apagar(int id)
        {
            var raca = _contexto.Racas.Where(x => x.Id == id).FirstOrDefault();

            _contexto.Racas.Remove(raca);
            _contexto.SaveChanges();
        }

        public void Atualizar(Raca racaParaAlterar)
        {
            var raca = _contexto.Racas
                .Where(x => x.Id == racaParaAlterar.Id).FirstOrDefault();

            raca.Nome = racaParaAlterar.Nome;
            raca.Especie = racaParaAlterar.Especie;

            _contexto.Update(raca);
            _contexto.SaveChanges();
        }

        public void Cadastrar(Raca raca)
        {
            // INSERT NA TABELA DE RAÇAS
            _contexto.Racas.Add(raca);
            _contexto.SaveChanges();
        }

        public Raca ObterPorId(int id)
        {
            var raca = _contexto.Racas.Where(x => x.Id == id).FirstOrDefault();

            return raca;
        }

        public List<Raca> ObterTodos()
        {
            // Buscar todos os registros de raças
            // SELECT * FROM racas
            var racas = _contexto.Racas.ToList();

            return racas;
        }
    }
}
