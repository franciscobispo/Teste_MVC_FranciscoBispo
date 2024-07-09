# Sistema de Gerenciamento de Clientes

## Descrição

Este projeto é um sistema web para o gerenciamento de clientes de uma empresa. Ele permite cadastrar, visualizar, editar e excluir clientes. O sistema também inclui validação de CPF e CNPJ, e a remoção de clientes é feita de forma lógica (soft delete).

## Tecnologias Utilizadas

- **ASP.NET MVC 5**: Framework para construção de aplicações web em C#.
- **Entity Framework**: ORM para comunicação com o banco de dados.
- **HTML**: Linguagem de marcação para construção das páginas.
- **CSS**: Folhas de estilo para estilização das páginas.
- **jQuery**: Biblioteca JavaScript para manipulação do DOM.
- **jQuery Mask Plugin**: Plugin para aplicação de máscaras em campos de formulário.

## Funcionalidades

- **Cadastro de Clientes**: Permite cadastrar novos clientes com os campos Nome, Tipo (PF ou PJ), Documento, Data do Cadastro e Telefone.
- **Listagem de Clientes**: Exibe a lista de clientes cadastrados, com suporte a paginação e filtragem por nome e documento.
- **Edição de Clientes**: Permite editar os dados de clientes já cadastrados.
- **Exclusão de Clientes**: Permite excluir clientes cadastrados utilizando soft delete.
- **Validação de CPF/CNPJ**: Valida os documentos de clientes de acordo com o tipo (PF ou PJ) tanto no frontend quanto no backend.

## Instalação

1. Clone o repositório:
    ```sh
    git clone https://github.com/seu-usuario/seu-repositorio.git
    ```

2. Abra o projeto no Visual Studio.

3. Restaure os pacotes NuGet necessários:
    ```sh
    Update-Package -reinstall
    ```

4. Configure a string de conexão com o banco de dados no arquivo `Web.config`.

5. Execute as migrações para criar o banco de dados:
    ```sh
    Update-Database
    ```

6. Compile e execute a aplicação.

## Estrutura do Projeto

- **Controllers**: Contém os controladores da aplicação.
    - `CustomerController.cs`: Controlador responsável pelo gerenciamento de clientes.
- **Models**: Contém as classes de modelo.
    - `Customer.cs`: Modelo representando um cliente.
- **Views**: Contém as views da aplicação.
    - `Customer`: Contém as views relacionadas aos clientes (`Create`, `Edit`, `Delete`, `Details`, `Index`).
- **Scripts**: Contém arquivos JavaScript.
    - `validation.js`: Contém a lógica de validação de CPF e CNPJ.
- **Content**: Contém arquivos CSS.
    - `site.css`: Contém a estilização das páginas.

## Utilização

1. Acesse a aplicação pelo navegador.
2. Use o menu para navegar entre as diferentes funcionalidades:
    - **Cadastrar Cliente**: Preencha os campos e clique em "Salvar".
    - **Listar Clientes**: Visualize a lista de clientes, use os campos de busca para filtrar os resultados.
    - **Editar Cliente**: Clique em "Editar" ao lado do cliente que deseja modificar.
    - **Excluir Cliente**: Clique em "Excluir" ao lado do cliente que deseja remover.

## Licença

Este projeto é licenciado sob os termos da licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.
