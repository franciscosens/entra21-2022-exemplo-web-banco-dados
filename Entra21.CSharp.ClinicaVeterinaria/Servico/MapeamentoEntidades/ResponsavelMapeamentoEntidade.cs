using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Responsaveis;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoEntidades;

public class ResponsavelMapeamentoEntidade : IResponsavelMapeamentoEntidade
{
    public Responsavel ConstruirCom(ResponsavelCadastrarViewModel viewModel) =>
        new Responsavel
        {
            Idade = viewModel.Idade.GetValueOrDefault(),
            NomeCompleto = viewModel.NomeCompleto,
            Cpf = viewModel.Cpf
        };

    public Responsavel AtualizarCampos(Responsavel responsavel, ResponsavelEditarViewModel viewModel)
    {
        responsavel.NomeCompleto = viewModel.NomeCompleto;
        responsavel.Idade = viewModel.Idade.GetValueOrDefault();
        responsavel.Cpf = viewModel.Cpf;

        return responsavel;
    }
}