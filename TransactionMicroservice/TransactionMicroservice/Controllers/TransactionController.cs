using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionMicroservice.Models;
using TransactionMicroservice.Repositories;

namespace TransactionMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITranRepository _tranRepository;
        public TransactionController(ITranRepository tranRepository)
        {
            _tranRepository = tranRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllTransactions()
        {
            var transactions = await _tranRepository.GetAllTransactionsAsync();
            return Ok(transactions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionByID([FromRoute] int id)
        {
            var transaction = await _tranRepository.GetTransactionByIDAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddTransaction([FromBody] TransactionHistoryModel transactionHistory)
        {
            var id = await _tranRepository.AddTransactionAsync(transactionHistory);
            return CreatedAtAction(nameof(GetTransactionByID), new { id = id, controller = "transaction" }, id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction([FromBody] TransactionHistoryModel transactioHistory, [FromRoute] int id)
        {
            await _tranRepository.UpdateTransactionAsync(id, transactioHistory);
            return Ok();
        }
    }
}
