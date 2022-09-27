using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Enums;
using Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoViewModels;
using FluentAssertions;
using Xunit;

namespace Tests.Unit.Servico.MapeamentoViewModels
{
    public class ResponsavelViewModelMapeamentoViewModelsTests
    {
        private readonly IResponsavelViewModelMapeamentoViewModels _responsavelViewModelMapeamentoViewModels;

        public ResponsavelViewModelMapeamentoViewModelsTests()
        {
            _responsavelViewModelMapeamentoViewModels = new ResponsavelViewModelMapeamentoViewModels();
        }

        [Fact]
        public void Test_ConstruirCom_Sem_Contatos()
        {
            // Arrange
            var responsavel = new Responsavel
            {
                Id = 1,
                NomeCompleto = "Francisco",
                Idade = 30,
                Cpf = "123.456.789-10",
                Contatos = new List<ResponsavelContato>()
            };

            // Act
            var responsavelEditarViewModel = _responsavelViewModelMapeamentoViewModels
                .ConstruirCom(responsavel);

            // Assert
            responsavelEditarViewModel.Id.Should().Be(responsavel.Id);
            responsavelEditarViewModel.NomeCompleto.Should().Be(responsavel.NomeCompleto);
            responsavelEditarViewModel.Idade.Should().Be(responsavel.Idade);
            responsavelEditarViewModel.Cpf.Should().Be(responsavel.Cpf);

            responsavelEditarViewModel.Contatos.Should().BeEmpty();
        }

        [Fact]
        public void Test_ConstruirCom_Com_Dois_Contatos()
        {
            // Arrange
            var responsavel = new Responsavel
            {
                Id = 10,
                NomeCompleto = "Edilson",
                Cpf = "234.567.890-10",
                Idade = 39,
                Contatos = new List<ResponsavelContato>
                {
                    GerarResponsavelContato(1, ResponsavelContatoTipo.Celular,"(47) 98820-9281"),
                    GerarResponsavelContato(2, ResponsavelContatoTipo.Email, "edilson@gmail.com"),
                }
            };

            // Act
            var viewModel = _responsavelViewModelMapeamentoViewModels
                .ConstruirCom(responsavel);

            // Assert
            viewModel.Id.Should().Be(responsavel.Id);
            viewModel.NomeCompleto.Should().Be(responsavel.NomeCompleto);
            viewModel.Idade.Should().Be(responsavel.Idade);
            viewModel.Cpf.Should().Be(responsavel.Cpf);

            // Validar que contém dois contatos na lista de contatos
            viewModel.Contatos.Should().HaveCount(2);

            // Validar contatos
            // i de 0 até 1, pois contém 2 contatos
            for (var i = 0; i < responsavel.Contatos.Count; i++)
            {
                var contato = viewModel.Contatos[i];
                var contatoEsperado = responsavel.Contatos[i];

                contato.Id.Should().Be(contatoEsperado.Id);
                contato.Tipo.Should().Be(contatoEsperado.Tipo);
                contato.Valor.Should().Be(contatoEsperado.Valor);
            }
        }

        private ResponsavelContato GerarResponsavelContato(
            int id,
            ResponsavelContatoTipo tipo,
            string valor)
        {
            return new ResponsavelContato
            {
                Id = id,
                Tipo = tipo,
                Valor = valor
            };
        }
    }
}
