using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Veterinarios;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoEntidades
{
    public interface IVeterinarioMapeamentoEntidade
    {
        Veterinario ConstruirCom(VeterinarioCadastrarViewModel viewModel);
    }
}