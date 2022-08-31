using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Enums;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Consultas;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoEntidades;

public class ConsultaMapeamentoEntidade : IConsultaMapeamentoEntidade
{
    public Consulta ConstruirCom(ConsultaIniciarAgendamentoViewModel viewModel) =>
        new Consulta
        {
            PetId = viewModel.PetId.GetValueOrDefault(),
            VeterinarioId = viewModel.VeterinarioId.GetValueOrDefault(),
            DataConsulta = viewModel.DataConsulta.GetValueOrDefault(),
            Status = ConsultaStatus.Agendamento,
            Total = 0m
        };
}