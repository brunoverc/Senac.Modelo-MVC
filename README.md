# Projeto MVC com Visual Studio, .NET 8 e C#

Este é um modelo básico de projeto MVC utilizando Visual Studio, .NET 8 e C#. Ele inclui uma estrutura inicial para a criação de uma aplicação web com arquitetura MVC, incluindo referências aos projetos de API e Core, controllers básicos, middleware para interceptação de erros, e algumas páginas iniciais.

## Pré-requisitos

- Visual Studio (versão X ou superior)
- .NET 8 SDK
- Conhecimento básico em MVC e C#

## Iniciando

1. Faça um Fork do repositório para a sua conta:

2. Abra o projeto no Visual Studio.

3. Certifique-se de ter todas as dependências necessárias instaladas.

## Estrutura do Projeto

- `Controllers/`: Contém os controllers do projeto.
- `Extensions/`: Contém classes úteis, como a classe `CpfAnnotation` para validação de CPF.
- `Middleware/`: Contém middleware para interceptação de erros.
- `Shared/`: Contém arquivos compartilhados, como o layout `_Layout.cshtml` e a página de login parcial `_LoginPartial.cshtml`.

## Personalização

- **Main Controller**: Um controller base `MainController` já está criado para servir como ponto de partida para os seus controllers. Você pode herdar dele para criar novos controllers.
- **Controller de Identity**: Um controller de Identity já está criado. Você precisará modificá-lo para a sua estrutura.
- **Layout e Estilos**: O arquivo `_Layout.cshtml` dentro da pasta `Shared` está criado e contém importações de CSS e JS. Você precisará ajustar esses arquivos para a sua estrutura e estilos específicos.

## Injeção de Dependências

Lembre-se de adicionar as injeções de dependências entre seus services e interfaces correspondentes.

## Contribuição

Contribuições são bem-vindas! Se você encontrar algum problema ou tiver alguma sugestão, por favor, abra uma issue ou envie um pull request.
