using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.ResponsaveisContatos;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoViewModels;

public interface IResponsavelContatoMapeamentoViewModel
{
    ResponsavelContatoEditarViewModel ConstruirCom(ResponsavelContato responsavelContato);
}