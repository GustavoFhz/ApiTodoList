namespace ToDoList.Models
{
    public class CategoriaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        public List<TarefaModel> Tarefas { get; set; } = new();

    }
}
