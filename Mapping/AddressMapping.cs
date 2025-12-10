using IsabelliDoces.Dtos.AddressDtos;
using IsabelliDoces.Entities;

namespace IsabelliDoces.Mapping;

public static class AddressMapping
{
    public static AddressDto ToDto(this Address address) =>
        new(address.Id, address.Type, address.Street, address.Number, address.Cep, address.Complement);
}
