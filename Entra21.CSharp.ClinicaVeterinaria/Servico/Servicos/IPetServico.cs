using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Pets;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.Servicos;

public interface IPetServico
{
    bool Apagar(int id);

    Pet Cadastrar(PetCadastrarViewModel viewModel, string caminhoArquivos);
    bool Editar(PetEditarViewModel viewModel, string caminhoArquivos);
    Pet? ObterPorId(int id);
    IList<Pet> ObterTodos();
}