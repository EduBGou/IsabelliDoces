using IsabelliDoces.Dtos.ClientDtos;
using IsabelliDoces.Entities;

namespace IsabelliDoces.Mapping;

public static class ClientMapping
{
    public static Client ToEntity(this CreateClientDto dto)
    {
        return new Client
        {
            Name = dto.Name,
            Phone = dto.Phone,
            AddressId = dto.AddressId
        };
    }

    public static Client ToEntity(this UpdateClientDto dto, int id)
    {
        return new Client
        {
            Id = id,
            Phone = dto.Phone,
            AddressId = dto.AddressId
        };
    }

    public static ClientSummaryDto ToGameSummaryDto(this Client client)
    {
        return new ClientSummaryDto(
            client.Id,
            client.Name,
            client.Phone,
            client.Address!
        );
    }

    public static ClientDetailsDto ToGameDetailsDto(this Client client)
    {
        return new ClientDetailsDto(
            client.Id,
            client.Name,
            client.Phone,
            client.AddressId
        );
    }
}
