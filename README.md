📝 ToDoList API
Esta é uma API RESTful para gerenciamento de tarefas (ToDo), desenvolvida com ASP.NET Core. Ela permite criar, listar, atualizar e excluir tarefas.

🚀 Tecnologias Utilizadas
ASP.NET Core

Entity Framework Core

SQL Server

Swagger para documentação

📁 Estrutura do Projeto
O projeto está organizado em pastas como:

Controllers: controladores da API

DTOs: objetos de transferência de dados

Models: modelos de dados

Repositories: acesso ao banco de dados

Services: regras de negócio

Migrations: migrações do banco de dados

🔧 Como Executar
Pré-requisitos: .NET SDK instalado e acesso a um banco SQL Server.

Clone o repositório:
git clone https://github.com/seu-usuario/todolist-api.git

Navegue até o diretório do projeto:
cd todolist-api

Configure a string de conexão no arquivo appsettings.json, exemplo:

json
Copy
Edit
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=ToDoListDb;Trusted_Connection=True;"
}
Aplique as migrações com o Entity Framework:
dotnet ef database update

Execute a aplicação:
dotnet run

Acesse o Swagger para testar os endpoints:
https://localhost:{porta}/swagger

📌 Endpoints
GET /api/tarefas – Lista todas as tarefas

GET /api/tarefas/{id} – Retorna uma tarefa por ID

POST /api/tarefas – Cria uma nova tarefa

PUT /api/tarefas/{id} – Atualiza uma tarefa existente

DELETE /api/tarefas/{id} – Exclui uma tarefa

✅ Funcionalidades
Criar tarefa

Atualizar tarefa

Listar tarefas

Excluir tarefa
