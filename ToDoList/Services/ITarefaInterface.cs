using ToDoList.Dto;
using ToDoList.Models;

namespace ToDoList.Services
{
    public interface ITarefaInterface
    {
        Task<ResponseModel<TarefaModel>> RegistrarTarefa(TarefaCriacaoDto tarefaCriacaoDto);
        Task<ResponseModel<List<TarefaModel>>>ListarTarefas();
        Task<ResponseModel<TarefaModel>> BuscarTarefaPorId(int id);
        Task<ResponseModel<TarefaModel>> EditarTarefa(TarefaEdicaoDto tarefaEdicaoDto);
        Task<ResponseModel<TarefaModel>> RemoverTarefa(int id);
    }
}
