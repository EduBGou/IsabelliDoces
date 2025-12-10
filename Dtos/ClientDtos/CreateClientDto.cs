using System.ComponentModel.DataAnnotations;

namespace IsabelliDoces.Dtos.ClientDtos;

public record class CreateClientDto(
    [Required][StringLength(50)]
    string Name,

    [Required][StringLength(20)]
    string Phone,

    int AddressId
);