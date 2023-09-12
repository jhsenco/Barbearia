using Barbearia.Models;

namespace Barbearia.Repositorios.Interfaces
{
    public interface IServicoRepositorio
    {
        Task<List<ServicoModel>> BuscarServicos();
        Task<ServicoModel> BuscarPorId(int id);
        Task<ServicoModel>Adicionar(ServicoModel servico);
        Task<ServicoModel>Atualizar(ServicoModel servico, int id);
        Task<bool> Apagar(int id);




    }
}
