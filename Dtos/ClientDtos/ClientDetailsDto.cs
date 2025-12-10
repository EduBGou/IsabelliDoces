namespace IsabelliDoces.Dtos.ClientDtos;

public record class ClientDetailsDto(
    int Id,
    string Name,
    string Phone,
    int AddressId
);