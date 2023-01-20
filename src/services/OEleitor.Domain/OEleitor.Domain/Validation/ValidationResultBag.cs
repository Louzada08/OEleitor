using FluentValidation.Results;

namespace OEleitor.Domain.Validation
{
    public class ValidationResultBag : ValidationResult
    {
        public object? Data { get; set; }
    }
}
