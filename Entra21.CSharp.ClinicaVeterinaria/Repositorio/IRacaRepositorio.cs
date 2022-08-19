using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio
{
    public interface IRacaRepositorio
    {
        void Cadastrar(Raca raca);
        List<Raca> ObterTodos();
        void Atualizar(Raca racaParaAlterar);
        void Apagar(int id);
        Raca ObterPorId(int id);
    }
}