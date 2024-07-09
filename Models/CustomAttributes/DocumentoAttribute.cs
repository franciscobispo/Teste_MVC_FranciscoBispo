using System.ComponentModel.DataAnnotations;
using Teste_MVC_FranciscoBispo.Enums;

namespace Teste_MVC_FranciscoBispo.Models.CustomAttributes;

public class DocumentoAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var customer = (Cliente)validationContext.ObjectInstance;
        var documento = value as string;

        if (string.IsNullOrEmpty(documento))
        {
            return new ValidationResult("Campo 'documento' é obrigatório.");
        }

        if (customer.Tipo == TipoClienteEnum.PF && !IsValidCPF(documento))
        {
            return new ValidationResult("CPF inválido.");
        }

        if (customer.Tipo == TipoClienteEnum.PJ && !IsValidCNPJ(documento))
        {
            return new ValidationResult("CNPJ inválido.");
        }

        return ValidationResult.Success;
    }

    public static bool IsValidCPF(string cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf))
            return false;

        cpf = cpf.Replace(".", "").Replace("-", "");

        if (cpf.Length != 11 || cpf.All(c => c == cpf[0]))
            return false;

        var digits = cpf.Select(c => int.Parse(c.ToString())).ToArray();

        int sum = 0;
        for (int i = 0; i < 9; i++)
            sum += (10 - i) * digits[i];

        int remainder = sum % 11;
        int firstCheckDigit = remainder < 2 ? 0 : 11 - remainder;

        if (digits[9] != firstCheckDigit)
            return false;

        sum = 0;
        for (int i = 0; i < 10; i++)
            sum += (11 - i) * digits[i];

        remainder = sum % 11;
        int secondCheckDigit = remainder < 2 ? 0 : 11 - remainder;

        return digits[10] == secondCheckDigit;
    }

    public static bool IsValidCNPJ(string cnpj)
    {
        if (string.IsNullOrWhiteSpace(cnpj))
            return false;

        cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

        if (cnpj.Length != 14 || cnpj.All(c => c == cnpj[0]))
            return false;

        var digits = cnpj.Select(c => int.Parse(c.ToString())).ToArray();

        int[] weight1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] weight2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        int sum = 0;
        for (int i = 0; i < 12; i++)
            sum += digits[i] * weight1[i];

        int remainder = sum % 11;
        int firstCheckDigit = remainder < 2 ? 0 : 11 - remainder;

        if (digits[12] != firstCheckDigit)
            return false;

        sum = 0;
        for (int i = 0; i < 13; i++)
            sum += digits[i] * weight2[i];

        remainder = sum % 11;
        int secondCheckDigit = remainder < 2 ? 0 : 11 - remainder;

        return digits[13] == secondCheckDigit;
    }
}