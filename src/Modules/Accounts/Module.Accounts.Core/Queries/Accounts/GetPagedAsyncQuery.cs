using AutoMapper;
using AutoMapper.QueryableExtensions;
using Module.Accounts.Core.Abstractions;
using Module.Accounts.Core.Dtos;
using Shared.Core.Common.Messaging;
using Shared.Infrastructure.Common;
using Shared.Models.Models;

namespace Module.Accounts.Core.Queries.Accounts
{
    public record GetPagedAsyncQuery(int PageNumber = 1, int PageSize = 10) : IQuery<PaginatedList<AccountDto>>;

    internal sealed class GetPagedAsyncQueryHandler(
        IAccountDbContext context, IMapper mapper) : IQueryHandler<GetPagedAsyncQuery, PaginatedList<AccountDto>>
    {
        private readonly IAccountDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<PaginatedList<AccountDto>>> Handle(GetPagedAsyncQuery request, CancellationToken cancellationToken)
        {
            PaginatedList<AccountDto> accountDtoList = await _context.Accounts.OrderByDescending(x => x.AccountNumber)
               .ProjectTo<AccountDto>(_mapper.ConfigurationProvider)
               .PaginatedListAsync(request.PageNumber, request.PageSize);

            return Result.Success(accountDtoList);
        }
    }
}