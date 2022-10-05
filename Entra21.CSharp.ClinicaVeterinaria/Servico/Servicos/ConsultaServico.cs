using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Enums;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Repositorios;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Consultas;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.ConsultasProcedimentos;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.Servicos
{
    public class ConsultaServico : IConsultaServico
    {
        private readonly IConsultaRepositorio _repositorio;
        private readonly IProcedimentoServico _procedimentoServico;

        public ConsultaServico(
            IConsultaRepositorio repositorio, 
            IProcedimentoServico procedimentoServico)
        {
            _repositorio = repositorio;
            _procedimentoServico = procedimentoServico;
        }

        public Consulta Cadastrar(ConsultaCadastrarViewModel viewModel)
        {
            var consulta = new Consulta
            {
                PetId = viewModel.PetId,
                VeterinarioId = viewModel.VeterinarioId,
                DataHoraPrevista = viewModel.DataHoraPrevista,
                ValorPrevisto = viewModel.Valor,
                Procedimento = viewModel.Procedimento,
                Status = ConsultaStatus.Pendente,
                DataHoraInicio = DateTime.Now
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
                ValorPrevisto = x.ValorPrevisto,
                Veterinario = x.Veterinario.Nome,
                DataHoraPrevista = x.DataHoraPrevista,
                Status = (int)x.Status
            }).ToList();
        }

        public void Iniciar(ConsultaIniciarViewModel viewModel)
        {
            var consulta = _repositorio.ObterPorId(viewModel.Id);

            if (consulta == null)
                throw new Exception("Consulta não encontrada");

            consulta.Iniciar();

            _repositorio.Editar(consulta);
        }

        public void Cancelar(ConsultaCancelarViewModel viewModel)
        {
            var consulta = _repositorio.ObterPorId(viewModel.Id);

            if (consulta == null)
                throw new Exception("Consulta não encontrada");

            consulta.Cancelar(viewModel.Motivo);

            _repositorio.Editar(consulta);
        }

        public void Finalizar(ConsultaFinalizarViewModel viewModel)
        {
            var consulta = _repositorio.ObterPorId(viewModel.Id);

            if (consulta == null)
                throw new Exception("Consulta não encontrada");

            consulta.Finalizar(viewModel.Valor);
            
            _repositorio.Editar(consulta);
        }

        public void AdicionarProcedimento(ConsultaAdicionarProcedimentoViewModel viewModel)
        {
            var consulta = _repositorio.ObterPorId(viewModel.ConsultaId);

            if (consulta == null)
                throw new Exception("Consulta não encontrada");
            
            var procedimento = _procedimentoServico.ObterPorId(viewModel.ConsultaId);

            if (procedimento == null)
                throw new Exception("Procedimento não encontrada");

            consulta.AdicionarProcedimento(procedimento);
            
            _repositorio.Editar(consulta);
        }
    }
}
