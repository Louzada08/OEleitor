using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace OEleitor.Domain.DomainObjects;
/// <summary>
/// Remover acentos e caracteres especiais. Ex.: ã => a, ç => c
/// </summary>
public static class StringFuncoes
{
    public static string RemoverAcentosECaracteresEspeciais(string entrada)
    {
        return new string(entrada
            .Normalize(System.Text.NormalizationForm.FormD)
            .ToCharArray()
            .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
            .ToArray());
    }

    public static string RetornarSomenteNumeros(string entrada)
    {
        return Regex.Replace(entrada, @"[^\d]", "");
    }
}