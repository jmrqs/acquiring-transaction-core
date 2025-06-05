using MediatR;
using Microsoft.AspNetCore.Mvc;
using Module.Accounts.Core.Queries.Accounts;
using Shared.Core.Abstractions;
namespace Module.Accounts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController(ISender sender) : ApiController(sender)
    {
        [HttpGet("{accountId}/customers/{customerId}")]
        public async Task<IActionResult> GetAsync([FromRoute] Guid accountId, [FromRoute] Guid customerId)
        {
            return Ok(await Sender.Send(new GetAsyncQuery(accountId, customerId)));
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetPagedAsync([FromRoute] int pageNumber = 1, [FromRoute] int pageSize = 20)
        {
            return Ok(await Sender.Send(new GetPagedAsyncQuery(pageNumber, pageSize)));
        }
    }
}