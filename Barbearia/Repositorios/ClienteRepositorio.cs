using Barbearia.Data;
using Barbearia.Models;
using Barbearia.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Barbearia.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly BarbeariaDBContex _dbContext;
        public ClienteRepositorio(BarbeariaDBContex barbeariaDBContex)
        {
            _dbContext = barbeariaDBContex;
        }

        public async Task<List<ClienteModel>> BuscarClientes()
        {
            return await _dbContext.Clientes.ToListAsync();
        }

        public async Task<ClienteModel> BuscarPorId(int id)
        {
            return await _dbContext.Clientes.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<ClienteModel> Adicionar(ClienteModel cliente)
        {
             await _dbContext.Clientes.AddAsync(cliente);
             await _dbContext.SaveChangesAsync();

            return cliente;
        }

        

        public async Task<ClienteModel> Atualizar(ClienteModel cliente, int id)
        {
           ClienteModel clientePorId = await BuscarPorId(id);

            if(clientePorId == null)
            {
                throw new Exception($"Cliente para o ID:{id} não foi encontrado.");
            }

            clientePorId.Nome = cliente.Nome;
            clientePorId.Telefone = cliente.Telefone;

            _dbContext.Clientes.Update(clientePorId);
            await _dbContext.SaveChangesAsync();
             
            return clientePorId;
        }

        public async Task<bool> Apagar(int id)
        {
            ClienteModel clientePorId = await BuscarPorId(id);

            if (clientePorId == null)
            {
                throw new Exception($"Cliente para o ID:{id} não foi encontrado.");
            }
            _dbContext.Clientes.Remove(clientePorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }

}



