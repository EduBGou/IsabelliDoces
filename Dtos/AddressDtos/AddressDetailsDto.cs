namespace IsabelliDoces.Dtos.AddressDtos;

public record class AddressDetailsDto()
{
    public int Id { get; init; }
    public int Type { get; init; }
    public string? Street { get; init; }
    public string? Number { get; init; }
    public string? Cep { get; init; }
    public string? Complement { get; init; }
}
