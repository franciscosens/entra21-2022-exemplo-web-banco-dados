using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.ResponsaveisContatos;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoEntidades;

public interface IResponsavelContatoMapeamentoEntidade
{
    ResponsavelContato ConstruirCom(ResponsavelContatoCadastrarViewModel viewModel);
    ResponsavelContato AtualizarCom(ResponsavelContato responsavelContato, ResponsavelContatoEditarViewModel viewModel);
}