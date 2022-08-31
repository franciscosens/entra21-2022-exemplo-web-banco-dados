using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Responsaveis;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.ResponsaveisContatos;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoViewModels;

public class ResponsavelViewModelMapeamentoViewModels : IResponsavelViewModelMapeamentoViewModels
{
    public ResponsavelEditarViewModel ConstruirCom(Responsavel responsavel) =>
        new ResponsavelEditarViewModel
        {
            Id = responsavel.Id,
            NomeCompleto = responsavel.NomeCompleto,
            Idade = responsavel.Idade,
            Cpf = responsavel.Cpf,
            Contatos = ConstruirContatosCom(responsavel.Contatos),
        };

    private IList<ResponsavelContatoViewModel> ConstruirContatosCom(IList<ResponsavelContato> contatos)
    {
        var viewModels = new List<ResponsavelContatoViewModel>();

        foreach (var contato in contatos)
        {
            viewModels.Add(new ResponsavelContatoViewModel
            {
                Id = contato.Id,
                Tipo = contato.Tipo,
                Valor = contato.Valor,
            });
        }

        return viewModels;
    }
}