using IsabelliDoces.Entities;

namespace IsabelliDoces.Dtos.ClientDtos;

public record class ClientSummaryDto(
    int Id,
    string Name,
    string Phone,
    Address Address
);