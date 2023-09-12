using Barbearia.Models;
using Barbearia.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Barbearia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly IServicoRepositorio _servicoRepositorio;
        public ServicoController(IServicoRepositorio servicoRepositorio)

        {
            _servicoRepositorio = servicoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<ServicoModel>>> ListarServicos()
        {
            List<ServicoModel> servicos = await _servicoRepositorio.BuscarServicos();
            return Ok(servicos); //para nao ficar dando erro nesse ínicio 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServicoModel>> BuscarPorId(int id)
        {
            ServicoModel servico = await _servicoRepositorio.BuscarPorId(id);
            return Ok(servico); //para nao ficar dando erro nesse ínicio 
        }

        [HttpPost]
        public async Task<ActionResult<ServicoModel>> Cadastrar([FromBody] ServicoModel servicoModel)
        {
            ServicoModel servico = await _servicoRepositorio.Adicionar(servicoModel);
            return Ok(servico);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServicoModel>> Atualizar([FromBody] ServicoModel servicoModel, int id)
        {
            servicoModel.Id = id;
            ServicoModel servico = await _servicoRepositorio.Atualizar(servicoModel, id);
            return Ok(servico);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServicoModel>> Apagar(int id)
        {
            bool deleted = await _servicoRepositorio.Apagar(id);
            return Ok(deleted);
        }
     }
    }
