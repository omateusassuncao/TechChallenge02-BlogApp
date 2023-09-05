# Tech Challenge 02 - Blog Notícias

# Solução contendo duas Aplicações ASP.NET Core utilizando framework .NET Core 6 
# Objetivos: Criar duas aplicações em uma única solução com objetivo de gerenciar notícias em um ambiente logado e com controle autenticação

Aplicação - BlogApp
Web App ASP.Net core MVC, utilizando Razor Pages para aprsentar as notícias para o usuário
As notícias são controlados por uma API Controller com 4 endpoints para criar, deletar, ler todas as notícias ou apenas um por id.
A API se comunica com a classe repository que faz a conexão com o Banco de dados.
Banco de dados utilizado é um Azure SQL Server e a modelagem foi configurada utilizando o Entity Framework Core

Aplicação - APIIdentity
Web App ASP.Net core MVC, utilizando o Framework Identity e o Entity Framework Core para criar toda a modelagem do mesmo banco de dados utilizado pela aplicação anterior.
Foram utilizadas as telas padrões de Razor page para registro e login do usuário, que utiliza uma Controller "AccountController" para fazer a comunicação entre as páginas e o Banco de dados
Uma classe Usuário e uma Controller específica foi criada para futura integração entre as duas aplciações

Próximos passsos:
- Integrar as aplicações para que as notícias sejam acessadas apenas após autenticação
- Criar relacionamento entre a classe Usuario e a classe notícias
- Alterar autorização para que o usuário acesse apenas as notícias em que é o Autor
