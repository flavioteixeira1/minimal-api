using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Infraestrutura.Db;
using Microsoft.AspNetCore.Mvc.Testing;
using MinimalApi;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.Hosting;
using MinimalApi.Dominio.Interfaces;
using Test.Mocks;
using Microsoft.Extensions.DependencyInjection;

namespace Test.Helpers;

public class Setup
{
    public const string PORT = "5087";
    public static TestContext testContext = default!;
    public static WebApplicationFactory<Startup> http = default!;
    public static HttpClient client = default!;

    public static void ClassInit(TestContext testContext)
    {
        Setup.testContext = testContext;
        Setup.http = new WebApplicationFactory<Startup>();

        Setup.http = Setup.http.WithWebHostBuilder(builder =>
       {
         builder.UseSetting("https_port", Setup.PORT).UseEnvironment("Testing");

         builder.ConfigureServices(services =>
    {
        services.AddScoped<IAdministradorServico, AdministradorServicoMock>();

    });
    });

        Setup.client = Setup.http.CreateClient();
    }   

    public static void ClassCleanup() {
        Setup.http.Dispose();
    }
    }
