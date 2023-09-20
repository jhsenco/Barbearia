using Barbearia.Models;
using Barbearia.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Barbearia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClienteController(IClienteRepositorio clienteRepositorio)

        {
            _clienteRepositorio = clienteRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<ClienteModel>>> BuscarClientes()
        {
            List<ClienteModel> clientes = await _clienteRepositorio.BuscarClientes();
            return Ok(clientes); //para nao ficar dando erro nesse ínicio 
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteModel>> BuscarPorId(int id)
        {
            ClienteModel cliente = await _clienteRepositorio.BuscarPorId(id);
            return Ok(cliente); //para nao ficar dando erro nesse ínicio 
        }
        [HttpPost]
        public async Task<ActionResult<ClienteModel>> Cadastrar([FromBody] ClienteModel clienteModel)
        {
            ClienteModel cliente = await _clienteRepositorio.Adicionar(clienteModel);
            return Ok(cliente);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ClienteModel>> Atualizar([FromBody] ClienteModel clienteModel, int id)
        {
            clienteModel.Id = id;
            ClienteModel cliente = await _clienteRepositorio.Atualizar(clienteModel, id);
            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ClienteModel>> Apagar(int id)
        {
            bool deleted = await _clienteRepositorio.Apagar(id);
            return Ok(deleted);
        }
     }
    }
