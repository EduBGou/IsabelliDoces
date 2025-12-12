using IsabelliDoces.Interfaces;
using IsabelliDoces.Utilities;

namespace IsabelliDoces.Entities;

public class CakeFlavor() : Entity, INameable
{
    [AttributePresentation(Label = "Nome", ListingOrder = 2)]
    public string Name { get; set; } = string.Empty;

    [AttributePresentation(Label = "Preço Unitário", ListingOrder = 3)]
    public decimal Price { get; set; }

    public override string ToString() => Name;
}

