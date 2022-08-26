using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Contatos;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoViewModels;

public class ResponsavelContatoMapeamentoViewModel : IResponsavelContatoMapeamentoViewModel
{
    public ResponsavelContatoEditarViewModel ConstruirCom(ResponsavelContato responsavelContato)
    {
        return new ResponsavelContatoEditarViewModel
        {
            // Observacao = responsavelContato.Observacao,
            Id = responsavelContato.Id,
            Tipo = (int)responsavelContato.Tipo,
            Valor = responsavelContato.Valor,
            ResponsavelId = responsavelContato.ResponsavelId
        };
    }
}