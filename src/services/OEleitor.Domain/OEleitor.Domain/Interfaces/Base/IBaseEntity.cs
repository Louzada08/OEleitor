using FluentValidation.Results;
using System;

namespace OEleitor.Domain.Interfaces.Base
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
        DateTime? DataCadastro { get; set; }
        DateTime? DataAlteracao { get; set; }
        DateTime? DataExclusao { get; set; }
    }
}
