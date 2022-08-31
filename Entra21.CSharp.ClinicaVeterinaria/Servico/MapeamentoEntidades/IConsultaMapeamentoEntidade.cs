using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Consultas;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoEntidades;

public interface IConsultaMapeamentoEntidade
{
    Consulta ConstruirCom(ConsultaIniciarAgendamentoViewModel viewModel);
}