namespace Api.WebApi.DTOs
{
    public record CreateAccountDto(string Name);
    public record UpdateAccountDto(string Name);
    public record AccountResponseDto(Guid Id, string Name);
}
