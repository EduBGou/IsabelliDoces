namespace IsabelliDoces.Entities;

public class Address
{
    public Address()
    {

    }

    public int Id { get; set; }
    public required int Type { get; set; }
    public required string Street { get; set; }
    public required string Number { get; set; } = string.Empty;
    public required string Cep { get; set; } = string.Empty;
    public string Complement { get; set; } = string.Empty;

    public override string ToString()
    {
        if (Complement is null)
            return $"[{Id}]: {Type}, {Street}, {Number}, CEP {Cep}";
        else
            return $"[{Id}]: {Type}, {Street}, {Number}, {Complement}, CEP {Cep}";
    }
}
