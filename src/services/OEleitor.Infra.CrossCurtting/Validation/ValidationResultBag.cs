using FluentValidation.Results;

namespace OEleitor.Infra.CrossCurtting.Validation
{
    public class ValidationResultBag : ValidationResult
    {
        public object? Data { get; set; }
    }
}
