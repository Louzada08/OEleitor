﻿using FluentValidation.Results;
using OEleitor.Domain.Validation;

namespace OEleitor.Domain.Messages
{
    public abstract class QueryHandler
    {
        protected ValidationResultBag ValidationResult;

        protected QueryHandler()
        {
            ValidationResult = new ValidationResultBag();
        }

        protected void AddError(string message)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, message));
        }
    }
}
