using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Dto;
using ToDoList.Enum;
using ToDoList.Models;

namespace ToDoList.Services
{
    public class TarefaService : ITarefaInterface
    {
        private readonly AppDbContext _context;
        public TarefaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<TarefaModel>> BuscarTarefaPorId(int id)
        {
            ResponseModel<TarefaModel> response = new ResponseModel<TarefaModel>();

            try
            {
                var tarefa = await _context.Tarefas.FindAsync(id);

                if(tarefa == null)
                {
                    response.Mensagem = "Tarefa não encontrada!";
                    return response;
                }
                response.Dados = tarefa;
                response.Mensagem = "Tarefa localizada!";

                return response;
               
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<TarefaModel>> EditarTarefa(TarefaEdicaoDto tarefaEdicaoDto)
        {
            ResponseModel<TarefaModel> response = new ResponseModel<TarefaModel>();

            try
            {
                var tarefaBanco = await _context.Tarefas.FindAsync(tarefaEdicaoDto.Id);

                if(tarefaBanco == null)
                {
                    response.Mensagem = "Tarefa não encontrada!";
                    return response;
                }
                tarefaBanco.Titulo = tarefaEdicaoDto.Titulo;
                tarefaBanco.Descricao = tarefaEdicaoDto.Descricao;
                tarefaBanco.Prioridade = tarefaEdicaoDto.Prioridade;
                tarefaBanco.DataVencimento = tarefaEdicaoDto.DataVencimento;
                tarefaBanco.CategoriaId = tarefaEdicaoDto.CategoriaId;
                tarefaBanco.DataAlteracao = DateTime.Now;

                _context.Update(tarefaBanco);
                await _context.SaveChangesAsync();

                response.Mensagem = "Tarefa editada com sucesso!";
                response.Dados = tarefaBanco;

                return response;
            }
            catch(Exception ex) 
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<TarefaModel>>> ListarTarefas()
        {
            ResponseModel<List<TarefaModel>> response = new ResponseModel<List<TarefaModel>>();

            try
            {
                var tarefas = await _context.Tarefas.ToListAsync();
                response.Dados = tarefas;
                response.Mensagem = "Tarefas localizadas!";
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<TarefaModel>> RegistrarTarefa(TarefaCriacaoDto tarefaCriacaoDto)
        {
            ResponseModel<TarefaModel> response = new ResponseModel<TarefaModel>();

            try
            {
               
                if (TarefaJaExiste(tarefaCriacaoDto))
                {
                    response.Mensagem = "Tarefa já registrada!";
                    response.Status = false;
                    return response;
                }


                // Criação da tarefa
                var tarefa = new TarefaModel
                {
                    Titulo = tarefaCriacaoDto.Titulo,
                    Descricao = tarefaCriacaoDto.Descricao,
                    Prioridade = tarefaCriacaoDto.Prioridade,
                    DataCriacao = DateTime.Now,
                    DataVencimento = tarefaCriacaoDto.DataVencimento,
                    Status = StatusTarefa.Pendente, 
                    CategoriaId = tarefaCriacaoDto.CategoriaId
                };

                
                _context.Tarefas.Add(tarefa);
                await _context.SaveChangesAsync();

                response.Mensagem = "Tarefa registrada com sucesso!";
                response.Status = true;
                response.Dados = tarefa; // Inclui a tarefa criada na resposta
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                
            }
            return response;
        }

        public async Task<ResponseModel<TarefaModel>> RemoverTarefa(int id)
        {
            ResponseModel<TarefaModel> response = new ResponseModel<TarefaModel>();

            try
            {
                var tarefa = await _context.Tarefas.FindAsync(id);

                if(tarefa == null)
                {
                    response.Mensagem = "Tarefa não localizada!";
                    return response;
                }

                response.Dados = tarefa;
                response.Mensagem = "Tarefa removida com sucesso!";

                _context.Remove(tarefa);
                await _context.SaveChangesAsync();

                return response;
            }
            catch(Exception ex)
            {
                response.Mensagem= ex.Message;
                response.Status = false;
                return response;
            }
        }

        public bool TarefaJaExiste(TarefaCriacaoDto tarefaCriacaoDto)
        {
            return _context.Tarefas.Any(item => item.Titulo == tarefaCriacaoDto.Titulo);
        }


    }
}
