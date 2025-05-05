using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
           
        }

        public DbSet<TarefaModel> Tarefas { get; set; }
        public DbSet<CategoriaModel> Categorias { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relacionamento 1:N Categoria -> Tarefa
            modelBuilder.Entity<CategoriaModel>()
                .HasMany(c => c.Tarefas)
                .WithOne(t => t.Categoria)
                .HasForeignKey(t => t.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Converter o enum Status para string no banco de dados
            modelBuilder.Entity<TarefaModel>()
            .Property(t => t.Status)
            .HasConversion<string>();

            modelBuilder.Entity<CategoriaModel>().HasData(
            new CategoriaModel { Id = 1, Nome = "Pessoal" },
            new CategoriaModel { Id = 2, Nome = "Trabalho" },
            new CategoriaModel { Id = 3, Nome = "Estudos" }
    );

        }

    }
}
