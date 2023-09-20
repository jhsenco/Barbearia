using Barbearia.Data;
using Barbearia.Models;
using Barbearia.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Barbearia.Repositorios
{
    public class BarbeariaRepositorio : IBarbeariaRepositorio
    {
        private readonly BarbeariaDBContex _dbContext;
        public BarbeariaRepositorio(BarbeariaDBContex barbeariaDBContex)
        {
            _dbContext = barbeariaDBContex;
        }

        public async Task<List<BarbeariaModel>> BuscarBarbearias()
        {
            return await _dbContext.Barbearias.ToListAsync();
        }

        public async Task<BarbeariaModel> BuscarPorId(int id)
        {
            return await _dbContext.Barbearias.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<BarbeariaModel> Adicionar(BarbeariaModel barbearia)
        {
            await _dbContext.Barbearias.AddAsync(barbearia);
            await _dbContext.SaveChangesAsync();

            return barbearia;
        }



        public async Task<BarbeariaModel> Atualizar(BarbeariaModel barbearia, int id)
        {
            BarbeariaModel barbeariaPorId = await BuscarPorId(id);

            if (barbeariaPorId == null)
            {
                throw new Exception($"Barbeiro para o ID:{id} não foi encontrado.");
            }

            barbeariaPorId.Nome = barbearia.Nome;
            barbeariaPorId.Endereco = barbearia.Endereco;
            barbeariaPorId.Telefone = barbearia.Telefone;

            _dbContext.Barbearias.Update(barbeariaPorId);
            await _dbContext.SaveChangesAsync();

            return barbeariaPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            BarbeariaModel barbeariaPorId = await BuscarPorId(id);

            if (barbeariaPorId == null)
            {
                throw new Exception($"Barbeiro para o ID:{id} não foi encontrado.");
            }
            _dbContext.Barbearias.Remove(barbeariaPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }

}



