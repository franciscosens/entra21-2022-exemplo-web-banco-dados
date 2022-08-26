using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Pets;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoEntidades;

public interface IPetMapeamentoEntidade
{
    Pet ConstruirCom(PetCadastrarViewModel viewModel, string caminho);
}