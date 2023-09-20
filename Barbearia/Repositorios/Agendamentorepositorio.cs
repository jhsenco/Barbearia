using Barbearia.Data;
using Barbearia.Models;
using Barbearia.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Barbearia.Repositorios
{
    public class AgendamentoRepositorio : IAgendamentoRepositorio
    {


        private readonly BarbeariaDBContex _dbContext;
        public AgendamentoRepositorio(BarbeariaDBContex barbeariaDBContex)
        {
            _dbContext = barbeariaDBContex;
        }

        public async Task<List<AgendamentoModel>> BuscarAgendamentos()
        {
            return await _dbContext.Agendamentos.ToListAsync();
        }

        public async Task<AgendamentoModel> BuscarPorId(int id)
        {
            return await _dbContext.Agendamentos.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<AgendamentoModel> Adicionar(AgendamentoModel agendamento)
        {
            await _dbContext.Agendamentos.AddAsync(agendamento);
            await _dbContext.SaveChangesAsync();

            return agendamento;
        }



        public async Task<AgendamentoModel> Atualizar(AgendamentoModel agendamentoModel)
        {
            var agendamentoPorId = await _dbContext.Agendamentos
                .FirstOrDefaultAsync(x => x.Id == agendamentoModel.Id);

            if (agendamentoPorId == null)
            {
                throw new Exception($"Agendamento com ID:{agendamentoModel.Id} não foi encontrado.");
            }

            // Atualize as propriedades do agendamentoPorId com base no agendamentoModel
            agendamentoPorId.ClienteId = agendamentoModel.ClienteId;
            agendamentoPorId.BarbeariaId = agendamentoModel.BarbeariaId;
            agendamentoPorId.BarbeiroId = agendamentoModel.BarbeiroId;
            agendamentoPorId.ServicoId = agendamentoModel.ServicoId;

            // Salve as alterações no banco de dados
            await _dbContext.SaveChangesAsync();

            return agendamentoPorId;
        }


        public async Task<bool> Apagar(int id)
        {
            AgendamentoModel agendamentoPorId = await BuscarPorId(id);

            if (agendamentoPorId == null)
            {
                throw new Exception($"Barbeiro para o ID:{id} não foi encontrado.");
            }
            _dbContext.Agendamentos.Remove(agendamentoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        
    }

}



