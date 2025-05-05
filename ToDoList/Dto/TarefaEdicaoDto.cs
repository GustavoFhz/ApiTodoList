using System.ComponentModel.DataAnnotations;
using ToDoList.Enum;

namespace ToDoList.Dto
{
    public class TarefaEdicaoDto
    {
        [Required(ErrorMessage = "Informe o ID da tarefa")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o título")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Digite a descrição")]
        public string Descricao { get; set; } = string.Empty;

        [Range(1, 5, ErrorMessage = "A prioridade deve estar entre 1 e 5.")]
        public int Prioridade { get; set; }

        public DateTime DataVencimento { get; set; }
        public DateTime DataAlteracao { get; set; }

        public DateTime DataConclusao { get; set; }

        public int CategoriaId { get; set; }

        public StatusTarefa Status { get; set; }

        public bool Concluida => Status == StatusTarefa.Concluida;
    }
}
