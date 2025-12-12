using IsabelliDoces.Utilities;

namespace IsabelliDoces.Entities;

public class OrderLine() : Entity
{
    public Order? Order { get; set; }
    [AttributePresentation(Label = "Quantidade", ListingOrder = 3)]
    public int Amount { get; set; }
    [AttributePresentation(Label = "Sabor", ListingOrder = 2)]
    public CakeFlavor? CakeFlavor { get; set; }
}
