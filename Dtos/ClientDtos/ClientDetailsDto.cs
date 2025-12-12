namespace IsabelliDoces.Dtos.ClientDtos;

public record class ClientDetailsDto()
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public string? Phone { get; init; }
    public int AddressId { get; init; }
}