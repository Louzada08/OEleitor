﻿
namespace OEleitor.WebApp.MVC.Dtos
{
    public class UsuarioDTO
  {
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Funcao { get; set; }
    public bool Excluido { get; set; }
    public string Senha { get; set; }
    public string SenhaConfirmacao { get; set; }
  }

}