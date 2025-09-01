using MinimalApi.Dominio.Entidades;

namespace Teste.Domain.Entidades;
[TestClass]

public class AdministradorTeste
{
    [TestMethod]
    public void TestarGetSetPropriedades()
    {
        //Arrange
        var adm = new Administrador();

        //Act
        adm.Email = "teste@teste.com";
        adm.Senha = "456789";
        adm.Perfil = "Adm";
        adm.Id = 9;

        //Assert
        Assert.AreEqual(9, adm.Id);
        Assert.AreEqual("456789", adm.Senha);
        Assert.AreEqual("Adm", adm.Perfil);
        Assert.AreEqual("teste@teste.com", adm.Email);

    }
}
