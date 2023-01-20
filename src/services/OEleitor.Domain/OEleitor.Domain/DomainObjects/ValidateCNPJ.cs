using System;
using System.Text.RegularExpressions;

namespace OEleitor.Domain.DomainObjects
{
    public static class ValidationCnpj
    {
        public static bool IsValidCnpj(this string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj))
                return false;
            else
            {
                cnpj = cnpj.Trim();
                cnpj = cnpj.Replace(".", "").Replace("/", "").Replace("-", "");
                var isCarcater = Int64.TryParse(cnpj, out Int64 result);

                if (!isCarcater) return false;

                int[] d = new int[14];
                int[] v = new int[2];
                int j, i, sum;
                string sequence, numbers;

                numbers = Regex.Replace(cnpj, "[^0-9]", string.Empty);

                //verificando se todos os numeros são iguais
                if (new string(numbers[0], numbers.Length) == numbers) return false;

                // se a quantidade de dígitos numérios for igual a 14
                // iremos verificar como CNPJ
                else if (numbers.Length == 14)
                {
                    sequence = "6543298765432";
                    for (i = 0; i <= 13; i++) d[i] = Convert.ToInt32(numbers.Substring(i, 1));
                    for (i = 0; i <= 1; i++)
                    {
                        sum = 0;
                        for (j = 0; j <= 11 + i; j++)
                            sum += d[j] * Convert.ToInt32(sequence.Substring(j + 1 - i, 1));

                        v[i] = (sum * 10) % 11;
                        if (v[i] == 10) v[i] = 0;
                    }
                    return (v[0] == d[12] & v[1] == d[13]);
                }

                else return false;
            }
        }
    }

}
