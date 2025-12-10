using System.ComponentModel.DataAnnotations;

namespace IsabelliDoces.Dtos.ClientDtos;

public record class UpdateClientDto(
    [Required][StringLength(20)]
    string Phone,

    int AddressId
);
