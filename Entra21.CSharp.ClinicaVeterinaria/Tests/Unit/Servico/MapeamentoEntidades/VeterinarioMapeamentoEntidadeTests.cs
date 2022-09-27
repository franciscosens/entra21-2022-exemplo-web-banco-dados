using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoEntidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Veterinarios;
using FluentAssertions;
using Xunit;

namespace Tests.Unit.Servico.MapeamentoEntidades
{
    public class VeterinarioMapeamentoEntidadeTests
    {
        private readonly IVeterinarioMapeamentoEntidade _veterinarioMapeamentoEntidade;

        public VeterinarioMapeamentoEntidadeTests()
        {
            _veterinarioMapeamentoEntidade = new VeterinarioMapeamentoEntidade();
        }

        [Fact]
        public void Test_ConstruirCom()
        {
            // Arrange
            var viewModel = new VeterinarioCadastrarViewModel
            {
                Nome = "Felipe",
                Crmv = "202200010"
            };

            // Act
            var veterinario = _veterinarioMapeamentoEntidade.ConstruirCom(viewModel);

            // Assert
            veterinario.Nome.Should().Be(viewModel.Nome);
            veterinario.Crmv.Should().Be(viewModel.Crmv);
        }

        [Fact]
        public void Test_AtualizarCampos()
        {
            // Arrange
            var veterinario = new Veterinario
            {
                Idade = 25,
                Salario = 15_000.99m
            };

            var viewModelEditar = new VeterinarioEditarViewModel
            {
                Idade = 26,
                Salario = 16_000.99m,
                Id = 20
            };

            // Act
            _veterinarioMapeamentoEntidade.AtualizarCampos(veterinario, viewModelEditar);

            // Assert
            veterinario.Idade.Should().Be(viewModelEditar.Idade);
            veterinario.Salario.Should().Be(viewModelEditar.Salario);
        }
    }
}
