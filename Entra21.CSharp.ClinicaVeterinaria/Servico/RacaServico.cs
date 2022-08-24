using Entra21.CSharp.ClinicaVeterinaria.Repositorio;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Racas;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico
{
    /* A classe RacaServico irá implementar a interface IRacaService,
     ou seja, deverá honrar as clausulas definidos na interface (contrato) */

    public class RacaServico : IRacaServico
    {
        private readonly IRacaRepositorio _racaRepositorio;

        public RacaServico(IRacaRepositorio racaRepositorio)
        {
            _racaRepositorio = racaRepositorio;
        }

        public void Editar(RacaEditarViewModel racaEditarViewModel)
        {
            var raca = new Raca();
            raca.Id = racaEditarViewModel.Id;
            raca.Nome = racaEditarViewModel.Nome.Trim();
            raca.Especie = racaEditarViewModel.Especie;

            _racaRepositorio.Atualizar(raca);
        }

        public void Apagar(int id)
        {
            _racaRepositorio.Apagar(id);
        }

        public void Cadastrar(RacaCadastrarViewModel racaCadastrarViewModel)
        {
            var raca = new Raca();
            raca.Nome = racaCadastrarViewModel.Nome;
            raca.Especie = racaCadastrarViewModel.Especie;

            _racaRepositorio.Cadastrar(raca);
        }

        public Raca ObterPorId(int id)
        {
            var raca = _racaRepositorio.ObterPorId(id);

            return raca;
        }

        public List<Raca> ObterTodos()
        {
            var racasDoBanco = _racaRepositorio.ObterTodos();

            return racasDoBanco;
        }
    }
}
