using FluentValidation.Results;

namespace OEleitor.Infra.CrossCurtting.Messages
{
    public abstract class QueryHandler
    {
        protected ValidationResult ValidationResult;

        protected QueryHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AddError(string message)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, message));
        }
    }
}
