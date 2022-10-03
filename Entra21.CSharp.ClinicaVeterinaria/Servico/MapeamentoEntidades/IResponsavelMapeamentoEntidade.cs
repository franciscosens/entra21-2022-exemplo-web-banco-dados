using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Responsaveis;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoEntidades;

public interface IResponsavelMapeamentoEntidade
{
    Responsavel ConstruirCom(ResponsavelCadastrarViewModel viewModel);
    Responsavel AtualizarCampos(Responsavel responsavel, ResponsavelEditarViewModel viewModel);
}