using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tarefasAPI.Repositorios.Interfaces;

namespace tarefasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;
        public TarefaController(ITarefaRepositorio tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<TarefaModel>>> ListarTodas()
        {
            List<TarefaModel> tarefas = await _tarefaRepositorio.BuscarTodasTarefas();
            return Ok(tarefas);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<TarefaModel>>> BuscarPorId(Guid id)
        {
            TarefaModel tarefa = await _tarefaRepositorio.BuscarPorId(id);
            return Ok(tarefa);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<TarefaModel>> Atualizar([FromBody] TarefaModel tarefa, Guid id)
        {
            tarefa.Id = id;
            TarefaModel taref = await _tarefaRepositorio.BuscarPorId(id);
            await _tarefaRepositorio.Atualizar(tarefa, id);
            return Ok(taref);
        }
        [HttpPost]
        public async Task<ActionResult<TarefaModel>> Cadastrar([FromBody] TarefaModel tarefaModel)
        {
            TarefaModel tarefa = await _tarefaRepositorio.Adicionar(tarefaModel);
            return Ok(tarefa);
        }
        [HttpDelete]
        public async Task<ActionResult<TarefaModel>> Apagar(Guid id)
        {
            await _tarefaRepositorio.Apagar(id);
            return Ok();
        }
        
    }
}
