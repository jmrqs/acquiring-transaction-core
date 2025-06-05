using AutoMapper;
using MediatR;
using Module.Transactions.Core.Dtos;
using Polly;
using Shared.Core.Common.EventBus;
using Shared.Core.Interfaces.Sagas;

namespace Module.Transactions.Core.Commands.CardTransaction
{
    public record CardTransactionAsyncCommand(CardTransactionDto CreditPaymentDto) : IRequest<CardTransactionDto>;

    internal class CreditPaymentAsyncCommandHandler() : 
        IRequestHandler<CardTransactionAsyncCommand, CardTransactionDto>
    {
        //private readonly IMapper _mapper = mapper;
        //private readonly IEventBus _eventBus = eventBus;

        public async Task<CardTransactionDto> Handle(CardTransactionAsyncCommand request, CancellationToken cancellationToken)
        {
            //await _eventBus.PublishAsync<ICardTransactionAuthorized>(new
            //{
            //    CorrelationId = Guid.NewGuid(),
            //    CustomerId = request.CreditPaymentDto.CustomerId,
            //    AccountId = request.CreditPaymentDto.AccountId,
            //    CardInfo = request.CreditPaymentDto.CardInfo,
            //    CardType = request.CreditPaymentDto.CardType
            //});

            //return _mapper.Map<>();

            return await Task.FromException<CardTransactionDto>(new NotImplementedException());
        }
    }
}