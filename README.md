# Games Catalog API

## Descrição

Este projeto implementa uma API RESTful para um catálogo de jogos. Foi desenvolvido com o intuito de aplicar conceitos práticos de construção de APIs REST, realização de operações CRUD e interação com banco de dados PostgreSQL, encapsulando a lógica de negócios e persistência de dados.

## Tecnologias Utilizadas

- ASP.NET Core 5.0/6.0
- Entity Framework Core
- PostgreSQL
- Docker
- Swagger para documentação da API

## Funcionalidades

- Listar todos os jogos cadastrados.
- Buscar um jogo específico pelo ID.
- Adicionar um novo jogo ao catálogo.
- Atualizar os dados de um jogo existente.
- Remover um jogo do catálogo.

## Configuração Inicial

### Pré-requisitos

- .NET 5.0/6.0 SDK
- PostgreSQL 12+
- Visual Studio 2019/2022 ou VS Code

### Configurando o Banco de Dados

1.Instale o PostgreSQL ou use o Docker para criar uma instância do PostgreSQL.
2.Crie um banco de dados chamado gamescatalog.
3.Utilize o `docker-compose.yml` para configurar e executar o banco de dados automaticamente.
4.Aplique as migrações usando o comando dotnet ef database update para criar as tabelas necessárias no banco de dados.

### Executando o Projeto

1. Clone o repositório para a sua máquina local.
2. Abra a solução no Visual Studio ou VS Code.
3. Restaure os pacotes NuGet com o comando `dotnet restore`.
4. Configure sua string de conexão no appsettings.json ou configure as variáveis de ambiente para a string de conexão caso esteja usando Docker.
5. Inicie a aplicação com o comando `dotnet run` ou utilize o Docker Compose com `docker-compose up` para rodar a aplicação em um contêiner

## Uso

A API pode ser testada usando o Swagger, que é automaticamente servido na rota `/swagger` quando a aplicação está em execução. Além disso, as rotas da API podem ser acessadas utilizando ferramentas como Postman ou cURL.
