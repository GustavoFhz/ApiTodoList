using System.ComponentModel.DataAnnotations;
using ToDoList.Enum;
using ToDoList.Models;

namespace ToDoList.Dto
{
    public class TarefaCriacaoDto
    {
        [Required(ErrorMessage ="Digite o titulo")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Digite a descrição")]
        public string Descricao { get; set; } = string.Empty;
        public bool Concluida => Status == StatusTarefa.Concluida;
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime DataVencimento { get; set; } = DateTime.Now.AddDays(7); // padrão: 7 dias após criação
        public DateTime DataConclusao { get; set; } = DateTime.MinValue; // representa "não concluído"

        [Range(1, 5, ErrorMessage = "A prioridade deve estar entre 1 e 5.")]
        public int Prioridade { get; set; } = 1; // prioridade padrão: 1

        public int CategoriaId { get; set; }

        public StatusTarefa Status { get; set; } = StatusTarefa.Pendente;
    }
}
