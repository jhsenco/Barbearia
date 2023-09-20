using Barbearia.Models;

namespace Barbearia.Repositorios.Interfaces
{
    public interface IBarbeariaRepositorio
    {
        Task<List<BarbeariaModel>> BuscarBarbearias();
        Task<BarbeariaModel> BuscarPorId(int id);
        Task<BarbeariaModel> Adicionar(BarbeariaModel barbearia);
        Task<BarbeariaModel> Atualizar(BarbeariaModel barbearia, int id);
        Task<bool> Apagar(int id);




    }
}
