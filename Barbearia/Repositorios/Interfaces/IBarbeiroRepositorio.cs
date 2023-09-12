using Barbearia.Models;

namespace Barbearia.Repositorios.Interfaces
{
    public interface IBarbeiroRepositorio
    {
        Task<List<BarbeiroModel>> BuscarBarbeiros();
        Task<BarbeiroModel> BuscarPorId(int id);
        Task<BarbeiroModel>Adicionar(BarbeiroModel barbeiro);
        Task<BarbeiroModel>Atualizar(BarbeiroModel barbeiro, int id);
        Task<bool> Apagar(int id);




    }
}
