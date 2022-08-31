using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Repositorios;
using Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoEntidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Veterinarios;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.Servicos
{
    public class VeterinarioServico : IVeterinarioServico
    {
        private readonly IVeterinarioRepositorio _veterinarioRepositorio;
        private readonly IVeterinarioMapeamentoEntidade _mapeamento;

        public VeterinarioServico(
            IVeterinarioRepositorio veterinarioRepositorio, 
            IVeterinarioMapeamentoEntidade mapeamento)
        {
            _veterinarioRepositorio = veterinarioRepositorio;
            _mapeamento = mapeamento;
        }

        public bool Apagar(int id) => 
            _veterinarioRepositorio.Apagar(id);

        public Veterinario Cadastrar(VeterinarioCadastrarViewModel viewModel)
        {
            var veterinario = _mapeamento.ConstruirCom(viewModel);

            _veterinarioRepositorio.Cadastrar(veterinario);

            return veterinario;
        }

        public bool Editar(VeterinarioEditarViewModel viewModel)
        {
            var veterinario = _veterinarioRepositorio.ObterPodId(viewModel.Id);
            
            if (veterinario == null)
                return false;
            
            _mapeamento.AtualizarCampos(veterinario, viewModel);

            _veterinarioRepositorio.Editar(veterinario);

            return true;
        }

        public Veterinario? ObterPorId(int id) => 
            _veterinarioRepositorio.ObterPodId(id);

        public IList<Veterinario> ObterTodos(string pesquisa) =>
            _veterinarioRepositorio.ObterTodos(pesquisa);

        public IList<SelectViewModel> ObterTodosSelect2()
        {
            var veterinarios = _veterinarioRepositorio.ObterTodos(string.Empty);

            return veterinarios
                .Select(x => new SelectViewModel
                {
                    Id = x.Id,
                    Text = x.Nome
                })
                .ToList();
        }
    }
}
