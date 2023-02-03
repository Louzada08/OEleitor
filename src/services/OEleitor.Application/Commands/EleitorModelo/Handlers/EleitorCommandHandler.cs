using AutoMapper;
using FluentValidation.Results;
using MediatR;
using OEleitor.Application.Commands.EleitorModelo.Requests;
using OEleitor.Domain.Entities;
using OEleitor.Domain.Interfaces;
using OEleitor.Infra.CrossCurtting.Messages;
using OEleitor.Infra.CrossCurtting.Validation;
using System.Threading;
using System.Threading.Tasks;

namespace OEleitor.Application.Commands.EleitorModelo.Handlers
{
    public class EleitorCommandHandler : CommandHandler, 
        IRequestHandler<AdicionarEleitorCommand, ValidationResultBag>
    {
        private readonly IMapper _mapper;
        private readonly IEleitorRepository _eleitorRepo;
        public EleitorCommandHandler(IMapper mapper, IEleitorRepository eleitorRepository)
        {
            _mapper = mapper;
            _eleitorRepo = eleitorRepository;
        }

        public async Task<ValidationResultBag> Handle(AdicionarEleitorCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                ValidationResult.Errors.AddRange(request.ValidationResult.Errors);
                return ValidationResult;
            }

            var eleitores = await _eleitorRepo.GetAsync(x => x.Email.Contains(request.Email));

            if (eleitores is not null)
            {
                ValidationResult.Errors.Add(new ValidationFailure("Error", $"Eleitor já cadastrado."));
                return ValidationResult;
            }

            var eleitor = _mapper.Map<Eleitor>(request);

            var result = await _eleitorRepo.AddAsync(eleitor);
            var ok = await _eleitorRepo.UnitOfWork.CommitAsync();
            return ValidationResult;
        }
    }
}
