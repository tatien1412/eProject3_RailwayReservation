using MediatR;
using Microsoft.AspNetCore.Mvc;
using RailwayTransaction.Application.Queries.MasterManagement.CashTransaction;
using RailwayTransaction.Application.Commands.MasterManagement.CashTransaction;
using Microsoft.AspNetCore.Authorization;

namespace RailwayTransaction.Controllers
{
   // [Authorize(Roles = "Master Manager, Transaction Staff")]
    [ApiController]
    [Route("api/[controller]")]
    public class CashTransactionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CashTransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Query: Get all CashTransactions
        [HttpGet]
        public async Task<IActionResult> GetAllCashTransactions()
        {
            var query = new GetAllCashTransactionsQuery();
            var cashTransactions = await _mediator.Send(query);

            if (cashTransactions == null || cashTransactions.Count == 0)
            {
                return NotFound("No CashTransactions found");
            }

            return Ok(cashTransactions);
        }

        // Query: Get CashTransaction by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCashTransactionById(int id)
        {
            var query = new GetCashTransactionByIdQuery(id);
            var cashTransaction = await _mediator.Send(query);

            if (cashTransaction == null)
            {
                return NotFound();
            }

            return Ok(cashTransaction);
        }

        // Command: Create a new CashTransaction
        [HttpPost]
        public async Task<IActionResult> CreateCashTransaction([FromBody] CreateCashTransactionCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cashTransactionId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetCashTransactionById), new { id = cashTransactionId }, cashTransactionId);
        }

        // Command: Update an existing CashTransaction
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCashTransaction(int id, [FromBody] UpdateCashTransactionCommand command)
        {
            if (id != command.CashTransactionID)
            {
                return BadRequest("CashTransaction ID mismatch");
            }

            await _mediator.Send(command);
            return NoContent();
        }

        // Command: Delete a CashTransaction
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCashTransaction(int id)
        {
            await _mediator.Send(new DeleteCashTransactionCommand { CashTransactionID = id });
            return NoContent();
        }
    }
}
