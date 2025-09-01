using MinimalApi.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Infraestrutura.Db;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using MinimalApi.Dominio.Servicos;


namespace Teste.Domain.Entidades;

[TestClass]

public class AdministradorServicoTeste
{
    [TestMethod]

    public DbContexto CriarContextoDeTeste()
    {
        var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));
        var builder = new ConfigurationBuilder()
            .SetBasePath(path ?? Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        var configuration = builder.Build();

        return new DbContexto(configuration);
    }
    public void TestandoSalvarAdministrador()
    {
        //Arrange

        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");
        var adm = new Administrador();
        adm.Email = "teste@teste.com";
        adm.Senha = "456789";
        adm.Perfil = "Adm";
        adm.Id = 9;

        var administradorServico = new AdministradorServico(context);

        //Act
        administradorServico.Incluir(adm);

        //Assert
        Assert.AreEqual(1, administradorServico.Todos(1).Count());


    }
    
    [TestMethod]
     public void TestandoBuscaPorId()
    {
        //Arrange

        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");
        var adm = new Administrador();
        adm.Email = "teste@teste.com";
        adm.Senha = "456789";
        adm.Perfil = "Adm";
        //adm.Id = 9;

        var adm2 = new Administrador();
        adm2.Email = "teste2@teste.com";
        adm2.Senha = "111111";
        adm2.Perfil = "Adm";


        var administradorServico = new AdministradorServico(context);

        //Act
        administradorServico.Incluir(adm);
        administradorServico.Incluir(adm2);
        var admDoBanco = administradorServico.BuscaPorId(adm.Id);

        //Assert
        Assert.AreEqual(1, admDoBanco.Id);


    }
}
