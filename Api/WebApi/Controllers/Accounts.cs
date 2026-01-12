using Api.Application.Services;
using Microsoft.AspNetCore.Mvc;

using Api.WebApi.DTOs;

namespace Api.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly AccountsServices _service;

        public AccountsController(AccountsServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountResponseDto>>> GetAll()
        {
            var accounts = await _service.GetAllAsync();
            var dto = accounts.Select(a => new AccountResponseDto(a.Id, a.Name));
            return Ok(dto);
        }


        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AccountResponseDto>> GetById(Guid id)
        {
            var account = await _service.GetAsync(id);
            if (account is null) return NotFound(new { error = "Account not found." });
            return Ok(new AccountResponseDto(account.Id, account.Name));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateAccountDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                return BadRequest(new { error = "Name is required." });

            var id = await _service.CreateAsync(dto.Name);
            return CreatedAtAction(nameof(GetById), new { id }, new { id });
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

    }

}
