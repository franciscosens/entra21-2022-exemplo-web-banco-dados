using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Consultas;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoViewModels;

public class ConsultaMapeamentoViewModel : IConsultaMapeamentoViewModel
{
    public ConsultaIndexViewModel ConstruirConsultaIndexViewModelCom(Consulta consulta) =>
        new ConsultaIndexViewModel
        {
            Id = consulta.Id,
            Pet = consulta.Pet.Nome,
            Responsavel = consulta.Pet.Responsavel.NomeCompleto,
            Veterinario = consulta.Veterinario.Nome,
            DataConsulta = consulta.DataConsulta
        };
}