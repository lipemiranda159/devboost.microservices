# devboost.microservices
Grupo 4 - Projeto Itaú (Microservices)

## Tecnologias:

- ASP.NET Core 3.1
- ASP.NET WebApi Core with JWT Identity Authentication
- Entity Framework Core 3.1

## Arquitetura:

- DDD
- Repository
- BDD
- TDD

## Grupo 4 - Desenvolvedores

- Italo Vinicios
- Felipe Miranda
- Lucas Scheid 
- Marcos Alves 

## Instruções para rodar a cobertura de código
 
 - Ir até a pasta do projeto de testes
 - Executar o comando: dotnet test --collect:"XPlat Code Coverage" 
 - Após a execução do comando, dentro do mesmo local será gerada a pasta TesteResults + GUID identificador
 - Entrar nesta pasta <TesteResults + GUID identificador>
 - Executar o comando: reportgenerator "-reports:coverage.cobertura.xml" "-targetdir:C:\Temp" "-reporttypes:HTML"
 
 - Observação: No comando acima, verificar o local na opção -targetdir:C:\Temp, caso necessário, este local pode ser modificado