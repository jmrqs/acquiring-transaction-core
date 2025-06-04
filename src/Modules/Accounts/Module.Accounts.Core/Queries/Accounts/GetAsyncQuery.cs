using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Module.Accounts.Core.Abstractions;
using Module.Accounts.Core.Dtos;
using Shared.Core.Common.Messaging;
using Shared.Core.Exceptions;
using Shared.Models.Models;

namespace Module.Accounts.Core.Queries.Accounts
{
    public record GetAsyncQuery(Guid AccountId, Guid CustomerId) : IQuery<AccountDto>;

    internal sealed class GetAsyncQueryHandler(IAccountDbContext context, IMapper mapper)
        : IQueryHandler<GetAsyncQuery, AccountDto>
    {
        private readonly IAccountDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<AccountDto>> Handle(GetAsyncQuery request, CancellationToken cancellationToken)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync
                (m => m.AccountId == request.AccountId && m.CustomerId == request.CustomerId, cancellationToken)
                ?? throw new EntityNotFoundException("Acount");

            var dto = _mapper.Map<AccountDto>(account);
            
            return Result.Success(dto);
        }   
    }
}