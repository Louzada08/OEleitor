using FluentValidation.Results;
using OEleitor.Infra.CrossCurtting.Data;
using OEleitor.Infra.CrossCurtting.Validation;

namespace OEleitor.Infra.CrossCurtting.Messages
{
    public abstract class CommandHandler
    {
        protected ValidationResultBag ValidationResult;

        protected CommandHandler()
        {
            ValidationResult = new ValidationResultBag();
        }

        protected void AdicionarErro(string message)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, message));
        }

        protected async Task<ValidationResultBag> PersistData(IUnitOfWork uow)
        {
            if (!await uow.CommitAsync()) AdicionarErro("Houve um erro ao persistir os dados");

            return ValidationResult;
        }
    }
}
