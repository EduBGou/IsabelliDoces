using System.ComponentModel.DataAnnotations;

namespace IsabelliDoces.Dtos.ClientDtos;

public record class CreateClientDto()
{
    [Required][StringLength(50)]
    public string? Name { get; init; }

    [Required][StringLength(20)]
    public string? Phone { get; init; }

    public int AddressId { get; init; }
}