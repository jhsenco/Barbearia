using Barbearia.Models;

namespace Barbearia.Repositorios.Interfaces
{

    public interface IAgendamentoRepositorio
    {
    
        Task<List<AgendamentoModel>> BuscarAgendamentos();
        Task<AgendamentoModel> BuscarPorId(int id);
        Task<AgendamentoModel> Adicionar(AgendamentoModel agendamentoModel);
        Task<AgendamentoModel> Atualizar(AgendamentoModel agendamentoModel);
        Task<bool> Apagar(int id);
    }
}
