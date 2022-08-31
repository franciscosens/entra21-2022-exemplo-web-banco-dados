using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Consultas;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoViewModels;

public interface IConsultaMapeamentoViewModel
{
    ConsultaIndexViewModel ConstruirConsultaIndexViewModelCom(Consulta consulta);
}