using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.ResponsaveisContatos;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.Servicos;

public interface IResponsavelContatoServico
{
    ResponsavelContato Cadastrar(ResponsavelContatoCadastrarViewModel viewModel);
    ResponsavelContato? Apagar(int id);
    ResponsavelContatoEditarViewModel? ObterPorId(int contatoId);
    ResponsavelContato Editar(ResponsavelContatoEditarViewModel viewModel);
}