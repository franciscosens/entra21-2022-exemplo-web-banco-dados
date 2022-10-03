using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Enums;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Pets;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoEntidades;

public class PetMapeamentoEntidade : IPetMapeamentoEntidade
{
    public Pet ConstruirCom(PetCadastrarViewModel viewModel, string caminho) =>
        new Pet
        {
            Nome = viewModel.Nome,
            Altura = viewModel.Altura.GetValueOrDefault(),
            Peso = viewModel.Peso.GetValueOrDefault(),
            Genero = (PetGenero)viewModel.Genero,
            Idade = viewModel.Idade.GetValueOrDefault(),
            CaminhoArquivo = caminho,

            ResponsavelId = viewModel.ResponsavelId.GetValueOrDefault(),
            RacaId = viewModel.RacaId.GetValueOrDefault()
        };

    public void AtualizarCom(Pet pet, PetEditarViewModel petEditarViewModel, string caminho)
    {
        pet.Nome = petEditarViewModel.Nome;
        pet.Altura = petEditarViewModel.Altura.GetValueOrDefault();
        pet.Peso = petEditarViewModel.Peso.GetValueOrDefault();
        pet.Idade = petEditarViewModel.Idade.GetValueOrDefault();
        pet.RacaId = petEditarViewModel.RacaId.GetValueOrDefault();
        pet.ResponsavelId = petEditarViewModel.ResponsavelId.GetValueOrDefault();
        pet.Genero = (PetGenero) petEditarViewModel.Genero;

        if(!string.IsNullOrEmpty(caminho))
            pet.CaminhoArquivo = caminho;
    }
}