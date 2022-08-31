using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Enums;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.ResponsaveisContatos;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoEntidades;

public class ResponsavelContatoMapeamentoEntidade : IResponsavelContatoMapeamentoEntidade
{
    public ResponsavelContato ConstruirCom(ResponsavelContatoCadastrarViewModel viewModel) =>
        new ResponsavelContato
        {
            ResponsavelId = viewModel.ResponsavelId,
            Tipo = (ResponsavelContatoTipo)viewModel.Tipo.GetValueOrDefault(),
            Valor = viewModel.Valor
        };

    public ResponsavelContato AtualizarCom(ResponsavelContato responsavelContato, ResponsavelContatoEditarViewModel viewModel)
    {
        responsavelContato.Tipo = (ResponsavelContatoTipo)viewModel.Tipo.GetValueOrDefault();
        responsavelContato.Valor = viewModel.Valor;

        return responsavelContato;
    }
}