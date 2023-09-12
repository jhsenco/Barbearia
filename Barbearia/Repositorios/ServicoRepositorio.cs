using Barbearia.Data;
using Barbearia.Models;
using Barbearia.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Barbearia.Repositorios
{
    public class ServicoRepositorio : IServicoRepositorio
    {
        private readonly BarbeariaDBContex _dbContext;
        public ServicoRepositorio(BarbeariaDBContex barbeariaDBContex)
        {
            _dbContext = barbeariaDBContex;
        }

        public async Task<List<ServicoModel>> BuscarServicos()
        {
            return await _dbContext.Servicos
                .Include(x => x.Barbeiro)
                .ToListAsync();
        }

        public async Task<ServicoModel> BuscarPorId(int id)
        {
            return await _dbContext.Servicos
                .Include(x  => x.Barbeiro)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<ServicoModel> Adicionar(ServicoModel servico)
        {
             await _dbContext.Servicos.AddAsync(servico);
             await _dbContext.SaveChangesAsync();

            return servico;
        }

        

        public async Task<ServicoModel> Atualizar(ServicoModel servico, int id)
        {
           ServicoModel servicoPorId = await BuscarPorId(id);

            if(servicoPorId == null)
            {
                throw new Exception($"Serviço para o ID:{id} não foi encontrado.");
            }

            servicoPorId.Nome = servico.Nome;
            servicoPorId.Tipo = servico.Tipo;
            servicoPorId.BarbeiroId = servico.BarbeiroId;

            _dbContext.Servicos.Update(servicoPorId);
            await _dbContext.SaveChangesAsync();
             
            return servicoPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            ServicoModel servicoPorId = await BuscarPorId(id);

            if (servicoPorId == null)
            {
                throw new Exception($"Barbeiro para o ID:{id} não foi encontrado.");
            }
            _dbContext.Servicos.Remove(servicoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }

}



