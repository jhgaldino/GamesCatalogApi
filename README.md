# Games Catalog API

## Descrição

Este projeto implementa uma API REST para um catálogo de jogos, criada com o objetivo de aprender e aplicar os conceitos de APIs REST, operações CRUD e o uso do banco de dados PostgreSQL. A API permite que usuários gerenciem informações de jogos, incluindo operações para criar, ler, atualizar e deletar registros.

## Tecnologias Utilizadas

- ASP.NET Core 5.0/6.0
- Entity Framework Core
- PostgreSQL
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

1. Instale o PostgreSQL e crie um banco de dados chamado `gamescatalog`.
2. Execute o comando `dotnet ef database update` para aplicar as migrações e criar as tabelas necessárias.

### Executando o Projeto

1. Clone o repositório para a sua máquina local.
2. Abra a solução no Visual Studio ou VS Code.
3. Restaure os pacotes NuGet.
4. No arquivo appsettings.json, coloque as informacoes de conexao do seu banco de dados PostgreSQL.
5. Inicie o projeto com `dotnet run` ou utilizando o recurso de execução do Visual Studio.

## Uso

A API pode ser testada usando o Swagger, que é automaticamente servido na rota `/swagger` quando a aplicação está em execução. Além disso, as rotas da API podem ser acessadas utilizando ferramentas como Postman ou cURL.
