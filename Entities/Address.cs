using IsabelliDoces.Utilities;

namespace IsabelliDoces.Entities;

public class Address() : Entity
{
    [AttributePresentation(Label = "Logradouro", ListingOrder = 2)]
    public string Street { get; init; } = string.Empty;

    [AttributePresentation(Label = "Numero", ListingOrder = 3)]
    public string Number { get; set; } = string.Empty;

    [AttributePresentation(Label = "Complemento", ListingOrder = 4)]
    public string Complement { get; set; } = string.Empty;

    [AttributePresentation(Label = "CEP", ListingOrder = 5)]
    public string Cep { get; set; } = string.Empty;

    public override string ToString()
    {
        if (string.IsNullOrWhiteSpace(Complement))
            return $"[{Id}]: {Street}, {Number}, CEP {Cep}";
        else
            return $"[{Id}]: {Street}, {Number}, {Complement}, CEP {Cep}";
    }
}
