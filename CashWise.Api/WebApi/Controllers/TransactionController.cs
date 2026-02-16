using AutoMapper;
using CashWise.Application.DTOs;
using CashWise.Application.Orchestrator.TransactionOrchestrator;
using CashWise.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CashWise.Api.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionOrchestrator _transactionOrchestrator;
        private readonly IMapper _transactionMapper;

        private IValidator<TransactionRequestDTO> _transactionValidator;

        public TransactionController(ITransactionOrchestrator transactionOrchestrator, IValidator<TransactionRequestDTO> transactionValidator, IMapper transactionMapper)
        {
            _transactionOrchestrator = transactionOrchestrator;
            _transactionValidator = transactionValidator;
            _transactionMapper = transactionMapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionResponseDTO>>> GetAllAsync()
        {
            var transactions = await _transactionOrchestrator.GetTransactionsAsync();

            var transactionsDTOs = transactions.Select(transaction => _transactionMapper.Map<TransactionResponseDTO>(transaction));
            
            return Ok(transactionsDTOs);
        }

        [HttpGet("{int:id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var transaction = await _transactionOrchestrator.GetTransactionByIdAsync(id);

            var transactionResponse = _transactionMapper.Map<TransactionResponseDTO>(transaction);

            return Ok(transactionResponse);

        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] TransactionRequestDTO dto)
        {
            var validationResult = await _transactionValidator.ValidateAsync(dto);
            
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            try
            {
                var transaction = _transactionMapper.Map<Transaction>(dto);
                var transactionId = await _transactionOrchestrator.CreateTransactionAsync(transaction);
                var transactionDto = _transactionMapper.Map<TransactionResponseDTO>(transaction);

                return CreatedAtAction(nameof(GetByIdAsync), new { transactionId }, transaction);
            }
            catch (ValidationException ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }
    }
}
