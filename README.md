# Financial Control API - Backend

![.NET](https://img.shields.io/badge/.NET-8-512BD4?logo=dotnet)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-14-4169E1?logo=postgresql)
![C#](https://img.shields.io/badge/C%23-11-239120?logo=c-sharp)
![Clean Architecture](https://img.shields.io/badge/Architecture-Clean-orange)
![JWT](https://img.shields.io/badge/Auth-JWT-black?logo=jsonwebtokens)

## 🎯 Sobre o Projeto

Este repositório contém o código-fonte do backend para um sistema de controle financeiro pessoal. A API foi desenvolvida em .NET 8 seguindo os princípios da **Clean Architecture** e **CQRS**, garantindo um código desacoplado, testável, escalável e de fácil manutenção.

O objetivo é fornecer uma base segura e robusta para gerenciar transações financeiras (receitas e despesas), categorias e usuários, com um sistema de autenticação moderno baseado em JWT.

---

## ✨ Funcionalidades

### ✅ Implementadas

* **Autenticação de Usuários:**
    * Endpoint para registro de novos usuários (`/api/users/register`).
    * Endpoint para login (`/api/users/login`) com retorno de token **JWT**.
    * Armazenamento seguro de senhas utilizando `ASP.NET Core Identity`.
* **Segurança:**
    * Endpoints de negócio protegidos, exigindo um token de autenticação válido.
    * O sistema identifica o usuário logado através do token, garantindo que cada usuário só possa acessar seus próprios dados.
* **Gerenciamento de Categorias:**
    * Criação de novas categorias associadas ao usuário logado.
    * Listagem de todas as categorias do usuário logado.
* **Gerenciamento de Transações:**
    * Criação de novas transações (receitas e despesas) associadas a uma categoria.
    * Listagem do extrato de transações do usuário logado, incluindo o nome da categoria.
* **CRUD Completo:** Implementação das funcionalidades de **Atualizar (Update)** e **Deletar (Delete)** para Transações e Categorias.
  
### 🚀 Funcionalidades Planejadas (Roadmap)

* **Dashboard e Resumos:** Endpoints para consolidar dados, como:
    * Saldo atual do usuário.
    * Total de receitas vs. despesas por período (mês/ano).
    * Gráfico de despesas por categoria.
* **Filtros Avançados:** Capacidade de filtrar o extrato de transações por data, tipo (receita/despesa) ou categoria.
* **Testes Automatizados:** Implementação de testes unitários e de integração com **NUnit** e **NSubstitute**.
* **Integração com Frontend:** Servir como base para a aplicação frontend a ser desenvolvida em **React**.

---

## 🛠️ Tecnologias e Arquitetura

Este projeto foi construído com uma seleção de tecnologias e padrões modernos do ecossistema .NET:

* **Framework:** .NET 8
* **Linguagem:** C# 12
* **Arquitetura:** Clean Architecture
* **Padrões de Design:**
    * **CQRS (Command Query Responsibility Segregation)** com a biblioteca `MediatR`.
    * **Repositório Genérico** e **Unit of Work**.
    * **Injeção de Dependência** nativa do .NET.
* **Banco de Dados:** PostgreSQL 14+
* **ORM (Object-Relational Mapper):** Entity Framework Core 8
* **Autenticação e Autorização:**
    * ASP.NET Core Identity para gerenciamento de usuários.
    * JSON Web Tokens (JWT) para autenticação stateless.
* **API:**
    * ASP.NET Core Web API
    * Documentação automática com **Swagger (OpenAPI)**.

---

## 🚀 Como Executar o Projeto (Getting Started)

Siga os passos abaixo para clonar e executar o projeto em seu ambiente local.

### Pré-requisitos

* **[.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)**
* **[Git](https://git-scm.com/)**
* Uma instância do **[PostgreSQL](https://www.postgresql.org/download/)** rodando localmente ou em um container.
* Um cliente de banco de dados (opcional, mas recomendado), como **DBeaver** ou **pgAdmin**.
* **Visual Studio 2022** ou **VS Code** com as extensões para C#.

### Passos para Instalação

1.  **Clone o repositório:**
    ```bash
    git clone [https://github.com/seu-usuario/seu-repositorio.git](https://github.com/seu-usuario/seu-repositorio.git)
    cd seu-repositorio
    ```

2.  **Configure as Conexões:**
    * No projeto `FinancialControl.Api`, renomeie o arquivo `appsettings.Development.json.example` para `appsettings.Development.json` (ou edite o `appsettings.json` diretamente).
    * Abra o arquivo e ajuste a `ConnectionStrings` e a `Jwt:Key`.

    ```json
    {
      "ConnectionStrings": {
        "FinancialControlDb": "Host=localhost;Port=5432;Database=FinancialControlDb;Username=postgres;Password=sua_senha_aqui"
      },
      "Jwt": {
        "Key": "SEU_SEGREDO_SUPER_SECRETO_E_LONGO_PARA_DESENVOLVIMENTO",
        "Issuer": "FinancialControl.Api",
        "Audience": "FinancialControl.Clients"
      }
    }
    ```

3.  **Abra a Solução:**
    * Abra o arquivo `FinancialControl.sln` com o Visual Studio 2022.
    * O Visual Studio deve restaurar os pacotes NuGet automaticamente. Se não, clique com o botão direito na solução e escolha "Restore NuGet Packages".

4.  **Aplique as Migrations do Banco de Dados:**
    * No Visual Studio, abra o **Package Manager Console** (`Tools -> NuGet Package Manager -> Package Manager Console`).
    * Certifique-se de que o projeto padrão (`Default project`) seja `FinancialControl.Infrastructure`.
    * Execute o comando para criar/atualizar o banco de dados:
    ```powershell
    Update-Database
    ```

5.  **Execute a Aplicação:**
    * Defina o projeto `FinancialControl.Api` como projeto de inicialização (Startup Project).
    * Pressione **F5** ou clique no botão de "Play" para iniciar a API.
    * O Swagger abrirá automaticamente no seu navegador, pronto para testar os endpoints!
