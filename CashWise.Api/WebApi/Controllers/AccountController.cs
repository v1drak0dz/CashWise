using Microsoft.AspNetCore.Mvc;

using CashWise.Api.WebApi.DTOs;
using CashWise.Application.Services.AccountService;

namespace CashWise.Api.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountResponseDto>>> GetAllAsync()
        {
            var accounts = await _accountService.GetAllAsync();
            var accountsDtos = accounts.Select(a => new AccountResponseDto(a.Id, a.BankName));
            return Ok(accountsDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AccountResponseDto>> GetByIdAsync(int id)
        {
            var account = await _accountService.GetAsync(id);
            if (account is null) return NotFound(new { error = "Account not found." });
            return Ok(new AccountResponseDto(account.Id, account.BankName));
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] CreateAccountDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                return BadRequest(new { error = "Name is required." });

            var id = await _accountService.CreateAsync(dto.Name);
            return CreatedAtAction(nameof(GetByIdAsync), new { id }, new { id });
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _accountService.DeleteAsync(id);
            return Ok($"Account with Id '{id}' removed successfully");
        }
    }
}
