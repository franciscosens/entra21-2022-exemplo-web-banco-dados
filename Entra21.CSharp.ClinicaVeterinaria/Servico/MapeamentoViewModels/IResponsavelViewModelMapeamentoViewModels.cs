using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Responsaveis;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoViewModels;

public interface IResponsavelViewModelMapeamentoViewModels
{
    ResponsavelEditarViewModel ConstruirCom(Responsavel responsavel);
}