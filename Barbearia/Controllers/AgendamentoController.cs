using Barbearia.Models;
using Barbearia.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Barbearia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly IAgendamentoRepositorio _agendamentoRepositorio;

        public AgendamentoController(IAgendamentoRepositorio agendamentoRepositorio)
        {
            _agendamentoRepositorio = agendamentoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<AgendamentoModel>>> BuscarAgendamentos()
        {
            List<AgendamentoModel> agendamentos = await _agendamentoRepositorio.BuscarAgendamentos();
            return Ok(agendamentos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AgendamentoModel>> BuscarPorId(int id)
        {
            AgendamentoModel agendamento = await _agendamentoRepositorio.BuscarPorId(id);
            return Ok(agendamento);
        }

        [HttpPost]
        public async Task<ActionResult<AgendamentoModel>> Agendar([FromBody] AgendamentoModel agendamentoModel)
        {
            AgendamentoModel agendamento = await _agendamentoRepositorio.Adicionar(agendamentoModel);
            return Ok(agendamento);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AgendamentoModel>> Atualizar(int id, [FromBody] AgendamentoModel agendamentoModel)
        {
            agendamentoModel.Id = id;
            AgendamentoModel agendamento = await _agendamentoRepositorio.Atualizar(agendamentoModel);
            return Ok(agendamento);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Cancelar(int id)
        {
            bool cancelado = await _agendamentoRepositorio.Apagar(id);
            return Ok(cancelado);
        }
    }
}
