using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.ResponsaveisContatos;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoViewModels;

public class ResponsavelContatoMapeamentoViewModel : IResponsavelContatoMapeamentoViewModel
{
    public ResponsavelContatoEditarViewModel ConstruirCom(ResponsavelContato responsavelContato) =>
        new ResponsavelContatoEditarViewModel
        {
            Id = responsavelContato.Id,
            Tipo = (int)responsavelContato.Tipo,
            Valor = responsavelContato.Valor,
            ResponsavelId = responsavelContato.ResponsavelId,
            Observacao = responsavelContato.Observacao
        };
}