Minimal Api - Example
You will need: dotnet SDK ver 8.0, mariadb or mysql database.

How to get started: with mysql or mariadb create a database named minimal_api,

Create a user named teste with password teste, (or change it  in appsettings.json)

Grant all privileges to teste user inside minimal_api database.

git clone https://github.com/flavioteixeira1/minimal-api.git

run dotnet-ef database update  (migrations) or

populate the minimal_api database with the dump file in Teste folder: Test/minimal_api.dump.sql

cd into the project path: cd minimal-api/API

and run with dotnet run

navigate to http://localhost:5087/swagger/

login running the post method under /administradores/login with:
{
  "email": "administrador@teste.com",
  "senha": "123456"
}

then get the token (jwt Bearer) and click into Authorize to run your testes

