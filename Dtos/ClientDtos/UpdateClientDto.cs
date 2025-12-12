namespace IsabelliDoces.Dtos.ClientDtos;

public record class UpdateClientDto()
{
    public string? Phone { get; init; }
    public int AddressId { get; init; }
}
