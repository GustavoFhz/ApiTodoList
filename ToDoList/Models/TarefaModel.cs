using ToDoList.Enum;

namespace ToDoList.Models
{
    public class TarefaModel
    {
       
            public int Id { get; set; }
            public string Titulo { get; set; } = string.Empty;
            public string Descricao { get; set; } = string.Empty;
            public bool Concluida { get; set; } = false;
            public DateTime DataCriacao { get; set; } = DateTime.Now;
            public DateTime DataVencimento { get; set; } = DateTime.Now.AddDays(7); // padrão: 7 dias após criação
            public DateTime DataConclusao { get; set; } = DateTime.MinValue; // representa "não concluído"
            public int Prioridade { get; set; } = 1; // prioridade padrão: 1
            public DateTime DataAlteracao { get; set; } = DateTime.Now;

            public int CategoriaId { get; set; }
            public CategoriaModel Categoria { get; set; }

            public StatusTarefa Status { get; set; } = StatusTarefa.Pendente;

    }
}



