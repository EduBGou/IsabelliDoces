namespace IsabelliDoces.Entities;

public class OrderLine() : Entity
{
    public int Amount { get; set; }
    public Order? Order { get; set; }
    public CakeFlavor? CakeFlavor { get; set; }
}
