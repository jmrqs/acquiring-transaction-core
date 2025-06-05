using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Core.Interfaces.Sagas;
using Shared.Core.Interfaces.Sagas.States;

namespace Module.Transactions.Infrastructure.Sagas
{
    public class CardTransactionStateMachine : MassTransitStateMachine<CardTransactionState>
    {
        public readonly ILogger<CardTransactionStateMachine> _logger;

        public State Submitted { get; private set; } = default!;
        public State Authorized { get; private set; } = default!;

        public Event<ICardTransactionSubmitted> CardTransactionSubmitted { get; private set; } = default!;
        public Event<ICardTransactionAuthorized> CardTransactionAuthorized { get; private set; } = default!;

        public CardTransactionStateMachine(ILogger<CardTransactionStateMachine> logger)
        {
            _logger = logger;

            InstanceState(x => x.CurrentState);

            Event(() => CardTransactionSubmitted, x => x.CorrelateById(context => context.Message.CorrelationId));
            Event(() => CardTransactionAuthorized, x => x.CorrelateById(context => context.Message.CorrelationId));

            Initially(
                When(CardTransactionSubmitted)
                .Then(context =>
                {
                    context.Saga.CorrelationId = context.Message.CorrelationId;
                    context.Saga.CustomerId = context.Message.CustomerId;
                    context.Saga.AccountId = context.Message.AccountId;
                    context.Saga.CardType = context.Message.CardType;
                    context.Saga.CardInfo = context.Message.CardInfo;
                    logger.LogInformation("Card transaction submitted: {CorrelationId}", context.Saga.CorrelationId);
                })
                .ThenAsync(SubmitTransactionMethod)
                .TransitionTo(Authorized));

            During(Authorized,
                When(CardTransactionAuthorized)
                  .Then(x => _logger.LogInformation("=> TransactionAuthorized"))
                  //.ThenAsync(TransactionAuthorizedMethod)
                  //.TransitionTo(TransactionCompleted)
                  //When(TransactionCancelled)
                  //.Then(x => _logger.LogInformation("=> TransactionCancelled"))
                  //.ThenAsync(TransactionCancelledMethod)
                  //.Finalize()
            );
        }

        private static Task SubmitTransactionMethod(BehaviorContext<CardTransactionState, ICardTransactionSubmitted> context)
        {
            return context.Publish<ICardTransactionAuthorized>(new
            {
                context.Message.CorrelationId,
                context.Message.CustomerId,
                context.Message.AccountId,
                context.Message.CardInfo,
                context.Message.CardType
            });
        }

        //private static Task TransactionAuthorizedMethod(BehaviorContext<CardTransactionState, ICardTransactionAuthorized> context)
        //{
        //    return context.Publish<ICardTransactionCompleted>(new
        //    {
        //        context.Message.CorrelationId,
        //        context.Message.CustomerId,
        //        context.Message.AccountId,
        //        context.Message.CardInfo,
        //        context.Message.CardType
        //    });
        //}
    }
}