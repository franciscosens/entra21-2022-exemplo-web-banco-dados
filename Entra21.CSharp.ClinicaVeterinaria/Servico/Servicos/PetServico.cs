using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Repositorios;
using Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoEntidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Pets;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.Servicos;

public class PetServico : IPetServico
{
    private const string PastaImagens = "Pets";
    private readonly IPetRespositorio _petRespositorio;
    private readonly IPetMapeamentoEntidade _mapeamentoEntidade;

    public PetServico(
        IPetRespositorio petRespositorio, 
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

    private string SalvarArquivo(PetCadastrarViewModel viewModel, string caminhoArquivos)
    {
        if (viewModel.Arquivo == null)
            return string.Empty;

        var path = Path.Combine(caminhoArquivos, PastaImagens);

        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
        
        var informacaoDoArquivo = new FileInfo(viewModel.Arquivo.FileName);
        var nomeArquivo = Guid.NewGuid() + informacaoDoArquivo.Extension;

        string caminhoArquivo = Path.Combine(path, nomeArquivo);
        
        using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
        {
            viewModel.Arquivo.CopyTo(stream);

            return nomeArquivo;
        }
    }

    public Pet? ObterPorId(int id)
    {
        throw new NotImplementedException();
    }

    public IList<Pet> ObterTodos() =>
        _petRespositorio.ObterTodos();
}