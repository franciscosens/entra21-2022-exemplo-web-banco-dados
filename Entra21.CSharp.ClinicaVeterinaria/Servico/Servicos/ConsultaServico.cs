using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Repositorios;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Consultas;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.Servicos
{
    public class ConsultaServico : IConsultaServico
    {
        private readonly IConsultaRepositorio _repositorio;

        public ConsultaServico(IConsultaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public Consulta Cadastrar(ConsultaCadastrarViewModel viewModel)
        {
            var consulta = new Consulta
            {
                PetId = viewModel.PetId,
                VeterinarioId = viewModel.VeterinarioId,
                DataHoraPrevista = viewModel.DataHoraPrevista,
                Valor = viewModel.Valor,
                Procedimento = viewModel.Procedimento
            };

            _repositorio.Cadastrar(consulta);

            return consulta;
        }

        public List<ConsultaIndexViewModel> ObterTodos()
        {
            var consultas = _repositorio.ObterTodos();

            //var viewModels = new List<ConsultaIndexViewModel>();

            //foreach (var consulta in consultas)
            //{
            //    viewModels.Add(new ConsultaIndexViewModel
            //    {
            //        Pet = consulta.Pet.Nome,
            //        Responsavel = consulta.Pet.Responsavel.NomeCompleto,
            //        Valor = consulta.Valor,
            //        Veterinario = consulta.Veterinario.Nome,
            //        DataHoraPrevista = consulta.DataHoraPrevista,
            //        Status = (int) consulta.Status
            //    });
            //}
            //return viewModels;

            return consultas.Select(x => new ConsultaIndexViewModel
            {
                Pet = x.Pet.Nome,
                Responsavel = x.Pet.Responsavel?.NomeCompleto ?? string.Empty,
                Valor = x.Valor,
                Veterinario = x.Veterinario.Nome,
                DataHoraPrevista = x.DataHoraPrevista,
                Status = (int)x.Status
            }).ToList();
        }
    }
}
