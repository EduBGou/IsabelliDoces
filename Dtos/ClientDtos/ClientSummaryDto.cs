using IsabelliDoces.Entities;

namespace IsabelliDoces.Dtos.ClientDtos;

public record class ClientSummaryDto()
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public string? Phone { get; init; }
    public Address? Address { get; init; }
}