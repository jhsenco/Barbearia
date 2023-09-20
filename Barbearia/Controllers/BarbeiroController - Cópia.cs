using Barbearia.Models;
using Barbearia.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Barbearia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarbeiroController : ControllerBase
    {
        private readonly IBarbeiroRepositorio _barbeiroRepositorio;
        public BarbeiroController(IBarbeiroRepositorio barbeiroRepositorio)

        {
            _barbeiroRepositorio = barbeiroRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<BarbeiroModel>>> BuscarBarbeiros()
        {
            List<BarbeiroModel> barbeiros = await _barbeiroRepositorio.BuscarBarbeiros();
            return Ok(barbeiros); //para nao ficar dando erro nesse ínicio 
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BarbeiroModel>> BuscarPorId(int id)
        {
            BarbeiroModel barbeiro = await _barbeiroRepositorio.BuscarPorId(id);
            return Ok(barbeiro); //para nao ficar dando erro nesse ínicio 
        }
        [HttpPost]
        public async Task<ActionResult<BarbeiroModel>> Cadastrar([FromBody] BarbeiroModel barbeiroModel)
        {
            BarbeiroModel barbeiro = await _barbeiroRepositorio.Adicionar(barbeiroModel);
            return Ok(barbeiro);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<BarbeiroModel>> Atualizar([FromBody] BarbeiroModel barbeiroModel, int id)
        {
            barbeiroModel.Id = id;
            BarbeiroModel barbeiro = await _barbeiroRepositorio.Atualizar(barbeiroModel, id);
            return Ok(barbeiro);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BarbeiroModel>> Apagar(int id)
        {
            bool deleted = await _barbeiroRepositorio.Apagar(id);
            return Ok(deleted);
        }
     }
    }
