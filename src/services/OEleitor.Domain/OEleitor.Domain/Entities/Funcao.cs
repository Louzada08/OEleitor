using System.Collections.Generic;

namespace OEleitor.Domain.Entities;

public class Funcao
{
    public int Id { get; set; }
    public string Descricao { get; set; }

    public ICollection<Usuario> Usuarios { get; set; }
}
