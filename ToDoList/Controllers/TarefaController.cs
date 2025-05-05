using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Dto;
using ToDoList.Services;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaInterface tarefaInterface;
        public TarefaController(ITarefaInterface tarefaService)
        {
            tarefaInterface = tarefaService;
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarTarefa(TarefaCriacaoDto tarefaCriacaoDto)
        {
            var tarefa = await tarefaInterface.RegistrarTarefa(tarefaCriacaoDto);
            return Ok(tarefa);
        }

        [HttpGet]
        public async Task<IActionResult> ListarTarefas()
        {
            var tarefa = await tarefaInterface.ListarTarefas();
            return Ok(tarefa);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarTarefaPorId(int id)
        {
            var tarefa = await tarefaInterface.BuscarTarefaPorId(id);
            return Ok(tarefa);
        }

        [HttpPut]
        public async Task<IActionResult> EditarTarefa(TarefaEdicaoDto tarefaEdicaoDto)
        {
            var tarefa = await tarefaInterface.EditarTarefa(tarefaEdicaoDto);
            return Ok(tarefa);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoverTarefa(int id)
        {
            var tarefa = await tarefaInterface.RemoverTarefa(id);
            return Ok(tarefa);
        }
        

    }
}
