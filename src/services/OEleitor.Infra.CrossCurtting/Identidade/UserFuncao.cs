using OEleitor.Infra.CrossCurtting.DomainObjects;

namespace OEleitor.Infra.CrossCurtting.Identidade
{
    public enum FuncoesEnum
  {
    Desenvolvedor = 4,
    Administrador = 3,
    Responsavel = 2,
    Operador = 1,
  }

  public class ObterFuncao
  {
    public string Nome { get; private set; }
    public int Codigo { get; private set; }

    public ObterFuncao() { }

    public ObterFuncao(int codigo = 0)
    {
      if (!ValidarCodigo(codigo)) throw new DomainException("Função inválida");
      var funcao = (FuncoesEnum)codigo;
      Nome = ObterEnumNomePeloId(codigo);
    }

    public ObterFuncao(string nome = "")
    {
      if (!ValidarNome(nome)) throw new DomainException("Função inválida");
      Codigo = ObterEnumIdPeloNome(nome);
    }

    public static int ObterEnumIdPeloNome(string nome)
    {
      var funcao = (FuncoesEnum)Enum.Parse(typeof(FuncoesEnum), nome);
      return (int)funcao;
    }

    public static string ObterEnumNomePeloId(int codigo)
    {
      var funcao = (FuncoesEnum)codigo;
      return funcao.ToString();
    }

    public static bool ValidarNome(string nome)
    {
      bool eValido = false;
      foreach (var valor in Enum.GetNames(typeof(FuncoesEnum)))
      {
        if (valor == nome)
        {
          eValido = true;
          return eValido;
        }
      }
      return eValido;
    }

    public static bool ValidarCodigo(int codigo)
    {
      bool eValido = false;
      foreach (var valor in Enum.GetValues(typeof(FuncoesEnum)).Cast<FuncoesEnum>())
      {
        if (valor.Equals(codigo))
        {
          eValido = true;
          return eValido;
        }
      }
      return eValido;
    }

    public static object RetornaEnumPeloNome(string nome)
    {
      foreach (var valor in Enum.GetNames(typeof(FuncoesEnum)))
      {
        if (valor == nome)
        {
          return Enum.Parse(typeof(FuncoesEnum), valor);
        }
      }
      return null;
    }
  } 
}
