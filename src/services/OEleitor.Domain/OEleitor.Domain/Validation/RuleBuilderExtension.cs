using FluentValidation;
using OEleitor.Domain.DomainObjects;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace OEleitor.Domain.Validation
{
    public static class RuleBuilderExtension
    {
        /// <summary>
        /// Valida se o campo possui caracteres especiais
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validatorProvider"></param>
        /// <returns></returns>

        public static IRuleBuilder<T, string> HasSpecialCharacters<T>(this IRuleBuilder<T, string> validatorProvider)
        {
            var options = validatorProvider
                .Custom((x, context) =>
                {
                    if (HasSpecialCharacters(x))
                        context.AddFailure($"Campo inválido");
                });
            return options;
        }
        public static bool HasSpecialCharacters(string stringToValidate)
        {
            var specialCharacters = "!@#$^&*()-+%¨".ToCharArray();
            return !(stringToValidate.IndexOfAny(specialCharacters) == -1);
        }

        /// <summary>
        /// Valida se uma string é composta somente de números
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validatorProvider"></param>
        /// <returns>Retorna mensagem de campo inválido caso a string não seja composta somente de números</returns>
        public static IRuleBuilder<T, string> IsNumber<T>(this IRuleBuilder<T, string> validatorProvider)
        {
            var options = validatorProvider
                .Custom((x, context) =>
                {
                    if (IsNumber(x))
                        context.AddFailure($"Campo inválido");
                });
            return options;
        }
        public static bool IsNumber(string stringToValidate)
        {
            return !(Regex.IsMatch(stringToValidate, @"^[0-9]+$"));
        }

        /// <summary>
        /// Indica se o e-mail é válido
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validatorProvider"></param>
        /// <returns>Retorna mensagem de campo inválido</returns>
        public static IRuleBuilder<T, string> IsValidEmail<T>(this IRuleBuilder<T, string> validatorProvider)
        {
            var options = validatorProvider
                .Custom((x, context) =>
                {
                    if (IsValidEmail(x))
                        context.AddFailure($"Campo e-mail inválido");
                });
            return options;
        }
        public static bool IsValidEmail(string stringToValidate)
        {
            var regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            return !(regexEmail.IsMatch(stringToValidate));
        }


        /// <summary>
        /// Indica se um telefone é válido
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validatorProvider"></param>
        /// <returns>Retorna mensagem de campo inválido</returns>
        public static IRuleBuilder<T, string> IsValidPhone<T>(this IRuleBuilder<T, string> validatorProvider)
        {
            var options = validatorProvider
                .Custom((x, context) =>
                {
                    if (IsValidPhone(x))
                        context.AddFailure($"Campo telefone inválido");
                });
            return options;
        }
        public static bool IsValidPhone(string stringToValidate)
        {
            var phoneDDD = new List<int>() { 11, 12, 13, 14, 15, 16, 17, 18, 19, 21, 22, 24, 27, 28, 31, 32, 33, 34, 35, 37, 38, 41, 42, 43, 44, 45, 46, 47, 48, 49, 51, 53, 54, 55, 61, 62, 63, 64, 65, 66, 67, 68, 69, 71, 73, 74, 75, 77, 79, 81, 82, 83, 84, 85, 86, 87, 88, 89, 91, 92, 93, 94, 95, 96, 97, 98, 99 };
            var isValid = Regex.IsMatch(stringToValidate, @"\((\d{2})\)[ ]\d{4,5}\-\d{4}");

            if (isValid)
            {
                Match resultado = Regex.Match(stringToValidate, @"\((\d{2})\)[ ]\d{4,5}\-\d{4}");

                var ddd = int.Parse(resultado.Groups[1].Value);

                isValid = phoneDDD.IndexOf(ddd) > -1;
            }

            return !isValid;
        }

        /// <summary>
        /// Indica se um CPF é válido
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validatorProvider"></param>
        /// <returns>Retorna mensagem de Campo CPF inválido</returns>
        public static IRuleBuilderOptions<T, string> IsValidCPF<T>(this IRuleBuilder<T, string> rule)
            => rule.Must(ValidateCPF.IsValidCpf).WithMessage("Campo CPF inválido");

        /// <summary>
        /// Indica se um CPNJ é válido
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validatorProvider"></param>
        /// <returns>Retorna mensagem de CNPJ inválido</returns>
        public static IRuleBuilderOptions<T, string> IsValidCNPJ<T>(this IRuleBuilder<T, string> rule)
            => rule.Must(ValidationCnpj.IsValidCnpj).WithMessage("Campo CNPJ inválido");

        /// <summary>
        /// Indica se uma placa de carro é válida
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validatorProvider"></param>
        /// <returns>Retorna mensagem de campo inválido</returns>
        public static IRuleBuilder<T, string> IsValidPlate<T>(this IRuleBuilder<T, string> validatorProvider)
        {
            var options = validatorProvider
                .Custom((x, context) =>
                {
                    if (IsValidPlate(x))
                        context.AddFailure($"Campo inválido");
                });
            return options;
        }
        public static bool IsValidPlate(string stringToValidate)
        {
            return !(Regex.IsMatch(stringToValidate.ToUpper(), @"^[A-Z]{3}-[0-9][0-9A-Z][0-9]{2}$"));
        }
    }
}
