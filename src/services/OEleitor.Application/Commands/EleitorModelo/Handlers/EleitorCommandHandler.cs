using AutoMapper;
using FluentValidation.Results;
using MediatR;
using OEleitor.Application.Commands.EleitorModelo.Requests;
using OEleitor.Domain.Entities;
using OEleitor.Domain.Interfaces;
using OEleitor.Domain.Messages;
using OEleitor.Domain.Validation;
using System.Threading;
using System.Threading.Tasks;

namespace OEleitor.Application.Commands.EleitorModelo.Handlers
{
    public class EleitorCommandHandler : CommandHandler, 
        IRequestHandler<AdicionarEleitorCommand, ValidationResultBag>
    {
        private readonly IMapper _mapper;
        private readonly IEleitorRepository _eleitorRepo;
        public EleitorCommandHandler(IMapper mapper, IEleitorRepository eleitorRepository
        ) : base()
        {
            _eleitorRepo = eleitorRepository;
            _mapper = mapper;
        }

        public async Task<ValidationResultBag> Handle(AdicionarEleitorCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                ValidationResult.Errors.AddRange(request.ValidationResult.Errors);
                return ValidationResult;
            }

            var eleitores = await _eleitorRepo.GetAsync(x => x.Nome.Contains(request.Nome));

            if (eleitores is not null)
                ValidationResult.Errors.Add(new ValidationFailure("Error", $"Eleitor já cadastrado."));
                return ValidationResult;

            var dados = new AdicionarEleitorCommand();
            var eleitor = _mapper.Map<Eleitor>(dados);

            await _eleitorRepo.AddAsync(eleitor);
            //await CommittAsync();

            return ValidationResult;
        }
    }
}
