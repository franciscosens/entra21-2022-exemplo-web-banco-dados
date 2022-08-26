using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Enums;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Pets;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoEntidades;

public class PetMapeamentoEntidade : IPetMapeamentoEntidade
{
    public Pet ConstruirCom(PetCadastrarViewModel viewModel, string caminho)
    {
        return new Pet
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
    }
}