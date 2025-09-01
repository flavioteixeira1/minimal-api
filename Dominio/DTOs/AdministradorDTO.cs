using System;

using MinimalApi.Dominio.DTOs.Enums;
namespace MinimalApi.DTOs;

public class AdministradorDTO
{
    public string Email { set; get; } = default!;

    public string Senha { set; get; } = default!;

    public Perfil? Perfil { get; set; } = default!;
}
 