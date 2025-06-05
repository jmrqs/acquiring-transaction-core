using MediatR;
using Microsoft.AspNetCore.Mvc;
using Module.Transactions.Core.Commands.CardTransaction;
using Module.Transactions.Core.Dtos;
using Shared.Core.Abstractions;

namespace Module.Transations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController(ISender sender) : ApiController(sender)
    {
        [HttpPost]
        public async Task<IActionResult> CardTransactionAsync([FromQuery] CardTransactionDto dto)
        {
            return Ok(await Sender.Send(new CardTransactionAsyncCommand(dto)));
        }
    }
}