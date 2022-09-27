using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Repositorios;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Racas;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.Servicos
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
            var raca = _racaRepositorio.ObterPorId(racaEditarViewModel.Id);

            if (raca == null)
                return;

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

        public IList<SelectViewModel> ObterTodosSelect2()
        {
            var pets = _racaRepositorio.ObterTodos();

            var selectViewModels = pets
                .Select(x => new SelectViewModel
                {
                    Id = x.Id,
                    Text = x.Nome
                })
                .ToList();

            return selectViewModels;
        }
    }
}
