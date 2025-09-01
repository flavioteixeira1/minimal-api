using System;

namespace MinimalApi.Dominio.DTOs.ModelViews;

public class Home
{
    public string Mensagem { get => "Bem vindo a API de veículos"; }
    public string Documentacao { get => "/swagger"; }
}
