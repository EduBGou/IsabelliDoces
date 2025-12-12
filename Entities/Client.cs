using System.ComponentModel.DataAnnotations.Schema;
using IsabelliDoces.Enums;
using IsabelliDoces.Interfaces;
using IsabelliDoces.Utilities;

namespace IsabelliDoces.Entities;

public class Client() : Entity, INameable
{
    [AttributePresentation(Label = "Nome", ListingOrder = 2)]
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public Address? Home { get; set; }

    public override string ToString() =>
        $"[{Id}]: {nameof(Name)} = {Name,30}, {nameof(Phone)} = {Phone,10}";
}
