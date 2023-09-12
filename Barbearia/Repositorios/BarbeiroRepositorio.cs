using Barbearia.Data;
using Barbearia.Models;
using Barbearia.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Barbearia.Repositorios
{
    public class BarbeiroRepositorio : IBarbeiroRepositorio
    {
        private readonly BarbeariaDBContex _dbContext;
        public BarbeiroRepositorio(BarbeariaDBContex barbeariaDBContex)
        {
            _dbContext = barbeariaDBContex;
        }

        public async Task<List<BarbeiroModel>> BuscarBarbeiros()
        {
            return await _dbContext.Barbeiros.ToListAsync();
        }

        public async Task<BarbeiroModel> BuscarPorId(int id)
        {
            return await _dbContext.Barbeiros.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<BarbeiroModel> Adicionar(BarbeiroModel barbeiro)
        {
             await _dbContext.Barbeiros.AddAsync(barbeiro);
             await _dbContext.SaveChangesAsync();

            return barbeiro;
        }

        

        public async Task<BarbeiroModel> Atualizar(BarbeiroModel barbeiro, int id)
        {
           BarbeiroModel barbeiroPorId = await BuscarPorId(id);

            if(barbeiroPorId == null)
            {
                throw new Exception($"Barbeiro para o ID:{id} não foi encontrado.");
            }

            barbeiroPorId.Nome = barbeiro.Nome;
            barbeiroPorId.Especialidade = barbeiro.Especialidade;

            _dbContext.Barbeiros.Update(barbeiroPorId);
            await _dbContext.SaveChangesAsync();
             
            return barbeiroPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            BarbeiroModel barbeiroPorId = await BuscarPorId(id);

            if (barbeiroPorId == null)
            {
                throw new Exception($"Barbeiro para o ID:{id} não foi encontrado.");
            }
            _dbContext.Barbeiros.Remove(barbeiroPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }

}



