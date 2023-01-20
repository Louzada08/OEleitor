using FluentValidation.Results;
using OEleitor.Domain.Interfaces;
using OEleitor.Domain.Validation;
using System.Threading.Tasks;

namespace OEleitor.Domain.Messages
{
    public abstract class CommandHandler
    {
        protected ValidationResultBag ValidationResult;

        protected CommandHandler()
        {
            ValidationResult = new ValidationResultBag();
        }

        protected void AddError(string message)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, message));
        }

        protected async Task<ValidationResultBag> PersistData(IUnitOfWork uow)
        {
            if (!await uow.Commit())
                AddError("Houve um erro ao persistir os dados");

            return ValidationResult;
        }
    }
}
