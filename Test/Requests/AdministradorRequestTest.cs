using System;
using MinimalApi.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Infraestrutura.Db;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using MinimalApi.Dominio.Servicos;
using Test.Helpers;
using MinimalApi.DTOs;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text;
using MinimalApi.Dominio.DTOs.ModelViews;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;

namespace Test.Requests;

[TestClass]
public class AdministradorRequestTest
{
    [ClassInitialize]

    public void ClassInit(TestContext testContext)
    {
        Setup.ClassInit(testContext);
    }
    [ClassCleanup]
    public static void ClassCleanup()
    {
        Setup.ClassCleanup(); 
    }

    [TestMethod]
    public async Task TestarGetSetPropriedades()
    {
        //Arrange
        var loginDTO = new LoginDTO
        {
            Email = "adm@teste.com",
            Senha = "123456"

        };
        var content = new StringContent(JsonSerializer.Serialize(loginDTO), Encoding.UTF8, "Application.json");

        //Act
        var response = await Setup.client.PostAsync("administradores/login", content);


        //Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        var result = await response.Content.ReadAsStringAsync();
        var admlogado = JsonSerializer.Deserialize<AdministradorLogado>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        Assert.IsNotNull(admlogado?.Email ?? "");
        Assert.IsNotNull(admlogado?.Token ?? "");
        Assert.IsNotNull(admlogado?.Perfil ?? "");

        Console.WriteLine(admlogado.Token);
       
    }

}
