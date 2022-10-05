using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Repositorios;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Procedimentos;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.Servicos
{
    public class ProcedimentoServico : IProcedimentoServico
    {
        public readonly IProcedimentoRepositorio _repositorio;

        public ProcedimentoServico(IProcedimentoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public List<ProcedimentoIndexViewModel> ObterTodos()
        {
            var procedimentos = _repositorio.ObterTodos();

            return procedimentos
                .Select(x => new ProcedimentoIndexViewModel
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Valor = x.Valor,
                })
                .ToList();
        }

        public Procedimento? ObterPorId(int id)
        {
            return _repositorio.ObterPorId(id);
        }
    }
}