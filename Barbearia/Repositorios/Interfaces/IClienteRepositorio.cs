using Barbearia.Models;

namespace Barbearia.Repositorios.Interfaces
{
    public interface IClienteRepositorio
    {
        Task<List<ClienteModel>> BuscarClientes();
        Task<ClienteModel> BuscarPorId(int id);
        Task<ClienteModel>Adicionar(ClienteModel cliente);
        Task<ClienteModel>Atualizar(ClienteModel cliente, int id);
        Task<bool> Apagar(int id);




    }
}
