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
    public class BairroCommandHandler : CommandHandler, 
        IRequestHandler<AdicionarBairroCommand, ValidationResultBag>
    {
        private readonly IMapper _mapper;
        private readonly IBairroRepository _bairroRepo;
        public BairroCommandHandler(IMapper mapper, IBairroRepository bairroRepository)
        {
            _mapper = mapper;
            _bairroRepo = bairroRepository;
        }

        public async Task<ValidationResultBag> Handle(AdicionarBairroCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                ValidationResult.Errors.AddRange(request.ValidationResult.Errors);
                return ValidationResult;
            }

            var bairros = await _bairroRepo.GetAsync(x => x.BairroNome.Contains(request.BairroNome));

            if (bairros is not null)
            {
                ValidationResult.Errors.Add(new ValidationFailure("Error", $"Bairro já cadastrado."));
                return ValidationResult;
            }

            var bairro = _mapper.Map<Bairro>(request);

            var result = await _bairroRepo.AddAsync(bairro);
            var ok = await _bairroRepo.UnitOfWork.CommitAsync();
            return ValidationResult;
        }
    }
}
