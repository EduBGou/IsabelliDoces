using IsabelliDoces.Enums;

namespace IsabelliDoces.Entities;

public class Address() : Entity
{
    public AddressType AddressType { get; set; } = AddressType.RESIDENTIAL;
    public string Street { get; init; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string Cep { get; set; } = string.Empty;
    public string Complement { get; set; } = string.Empty;

    public override string ToString()
    {
        if (string.IsNullOrWhiteSpace(Complement))
            return $"[{Id}]: {AddressType.ToString().ToLower()}, {Street}, {Number}, CEP {Cep}";
        else
            return $"[{Id}]: {AddressType.ToString().ToLower()}, {Street}, {Number}, {Complement}, CEP {Cep}";
    }
}
