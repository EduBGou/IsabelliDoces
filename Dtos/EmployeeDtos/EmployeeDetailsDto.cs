namespace IsabelliDoces.Dtos.EmployeeDtos;

public record class EmployeeDetailsDto
{
    public int Id { get; init; }
    public string Cpf { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string Phone { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    public int AddressId { get; init; }
}
