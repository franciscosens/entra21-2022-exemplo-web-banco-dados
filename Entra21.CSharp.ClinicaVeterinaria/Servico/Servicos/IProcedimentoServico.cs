using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Procedimentos;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.Servicos
{
    public interface IProcedimentoServico
    {
        List<ProcedimentoIndexViewModel> ObterTodos();
        Procedimento? ObterPorId(int id);
    }
}