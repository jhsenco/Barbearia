using Barbearia.Models;
using Barbearia.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Barbearia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarbeariaController : ControllerBase
    {
        private readonly IBarbeariaRepositorio _barbeariaRepositorio;
        public BarbeariaController(IBarbeariaRepositorio barbeariaRepositorio)

        {
            _barbeariaRepositorio = barbeariaRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<BarbeariaModel>>> BuscarBarbearias()
        {
            List<BarbeariaModel> barbearias = await _barbeariaRepositorio.BuscarBarbearias();

            return Ok(barbearias); //para nao ficar dando erro nesse ínicio 
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BarbeariaModel>> BuscarPorId(int id)
        {
            BarbeariaModel barbearia = await _barbeariaRepositorio.BuscarPorId(id);
            return Ok(barbearia); //para nao ficar dando erro nesse ínicio 
        }
        [HttpPost]
        public async Task<ActionResult<BarbeariaModel>> Cadastrar([FromBody] BarbeariaModel barbeariaModel)
        {
            BarbeariaModel barbearia = await _barbeariaRepositorio.Adicionar(barbeariaModel);
            return Ok(barbearia);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<BarbeariaModel>> Atualizar([FromBody] BarbeariaModel barbeariaModel, int id)
        {
            barbeariaModel.Id = id;
            BarbeariaModel barbearia = await _barbeariaRepositorio.Atualizar(barbeariaModel, id);
            return Ok(barbearia);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BarbeariaModel>> Apagar(int id)
        {
            bool deleted = await _barbeariaRepositorio.Apagar(id);
            return Ok(deleted);
        }
    }
}
