using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Repositorios;
using Entra21.CSharp.ClinicaVeterinaria.Servico.Helpers;
using Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoEntidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Pets;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.Servicos;

public class PetServico : IPetServico
{
    private readonly IPetRepositorio _petRespositorio;
    private readonly IPetMapeamentoEntidade _mapeamentoEntidade;

    public PetServico(
        IPetRepositorio petRespositorio,
        IPetMapeamentoEntidade mapeamentoEntidade)
    {
        _petRespositorio = petRespositorio;
        _mapeamentoEntidade = mapeamentoEntidade;
    }

    public bool Apagar(int id) =>
        _petRespositorio.Apagar(id);

    public Pet Cadastrar(PetCadastrarViewModel viewModel, string caminhoArquivos)
    {
        var caminho = SalvarArquivo(viewModel, caminhoArquivos);

        var pet = _mapeamentoEntidade.ConstruirCom(viewModel, caminho);

        _petRespositorio.Cadastrar(pet);

        return pet;
    }

    public bool Editar(PetEditarViewModel viewModel, string caminhoArquivos)
    {
        var pet = _petRespositorio.ObterPodId(viewModel.Id);
        
        if (pet == null)
            return false;

        var caminho = SalvarArquivo(viewModel, caminhoArquivos, pet.CaminhoArquivo);

        _mapeamentoEntidade.AtualizarCom(pet, viewModel, caminho);

        _petRespositorio.Editar(pet);

        return true;
    }

    private string SalvarArquivo(PetViewModel viewModel, string caminhoArquivos, string? arquivoAntigo = "")
    {
        if (viewModel.Arquivo == null)
            return string.Empty;

        var caminhoPastaImagens = Path.Combine(caminhoArquivos, ArquivoHelper.ObterCaminhoPastas());

        if (!Directory.Exists(caminhoPastaImagens))
            Directory.CreateDirectory(caminhoPastaImagens);

        if(!string.IsNullOrEmpty(arquivoAntigo))
            ApagarArquivoAntigo(caminhoPastaImagens, arquivoAntigo);

        var informacaoDoArquivo = new FileInfo(viewModel.Arquivo.FileName);
        var nomeArquivo = Guid.NewGuid() + informacaoDoArquivo.Extension;

        var caminhoArquivo = Path.Combine(caminhoPastaImagens, nomeArquivo);

        using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
        {
            viewModel.Arquivo.CopyTo(stream);

            return nomeArquivo;
        }
    }

    private void ApagarArquivoAntigo(string caminhoPastaImagens, string arquivoAntigo)
    {
        var caminhoArquivoAntigo = Path.Join(caminhoPastaImagens, arquivoAntigo);
        
        if(File.Exists(caminhoArquivoAntigo))
            File.Delete(caminhoArquivoAntigo);
    }

    public Pet? ObterPorId(int id) =>
        _petRespositorio.ObterPodId(id);

    public IList<Pet> ObterTodos() =>
        _petRespositorio.ObterTodos();
}