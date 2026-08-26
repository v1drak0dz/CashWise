    using CashWise.Application.Repositories;
    using CashWise.Domain.Entities;
    using Microsoft.AspNetCore.Mvc;

    namespace CashWise.Api.Controllers
    {
        [ApiController]
        [Route("[controller]")]
        public class TransactionsController(ITransactionRepository transactionRepository) : ControllerBase
        {
            /// <summary>
            /// Gets all <see cref="Transaction" />
            /// </summary>
            /// <returns></returns>
            [HttpGet]
            public async Task<ActionResult<List<Transaction>>> GetAllTransactionAsync() =>
                Ok(await transactionRepository.GetAllTransactionsAsync());

            /// <summary>
            /// Get a specific <see cref="Transaction"/>
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            /// <exception cref="NotImplementedException"></exception>
            [HttpGet("{id:int}")]
            public async Task<ActionResult<Transaction?>> GetTransactionByIdAsync(int id) =>
                Ok(await transactionRepository.GetTransactionByIdAsync(id));

            /// <summary>
            /// Create a new <see cref="Transaction" />
            /// </summary>
            /// <param name="transaction"></param>
            [HttpPost]
            public async Task<ActionResult> CreateTransactionAsync([FromBody] Transaction transaction)
            {
                await transactionRepository.CreateTransactionAsync(transaction);
                return CreatedAtAction(nameof(GetTransactionByIdAsync), transaction.Id, transaction); 
            }
                
        }
    }
