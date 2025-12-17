using IsabelliDoces.Entities;

namespace IsabelliDoces.Relations;

public class DeliveryPlace()
{
    public Client Client { get; set; } = null!;
    public Address Address {get; set; } = null!;
}
