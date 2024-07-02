# API Web com Autenticação e Autorização

## Descrição

Projeto de estudo sobre autenticação e autorização em aplicação API Web desenvolvida em C#. A aplicação é estruturada seguindo os conceitos da Clean Architecture, com divisão de responsabilidades em diferentes camadas.

## Estrutura do Projeto
- API: Contém os controladores e a configuração do Program.cs.
- Application: Inclui DTOs, serviços e interfaces.
- Domain: Define as entidades do domínio.
- Infra.Data: Responsável pelo contexto, repositórios e interfaces de acesso aos dados.
- JWT: Gerenciamento de geração de tokens JWT.

## Tecnologias Utilizadas
- SQLite: Banco de dados leve e fácil de configurar.
- JWT (JSON Web Token): Para autenticação e autorização.
- JWT Bearer: Implementação de autenticação baseada em tokens.

## Funcionalidades
- Cadastro de usuários
- Login de usuários
- Retorno de mensagens de sucesso ou erro
- Execução no Swagger para testes e documentação

## Instalação

1. Clone o repositório para sua máquina local.
    ```bash
    git clone https://github.com/brunohmsato/AuthAPI.git
    ```

2. Navegue até a pasta do projeto e restaure os pacotes.
    ```bash
    cd AuthAPI
    ```

    ``` bash
    dotnet restore
    ```

3. Execute a aplicação.

4. Acesse o Swagger no navegador para testar as funcionalidades.
    ``` bash
    https://localhost:7131/swagger
    ```
