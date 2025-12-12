using IsabelliDoces.Entities;
using IsabelliDoces.Utilities;

namespace IsabelliDoces.Relations;

public class DeliveryPlace()
{
    public Client Client { get; set; } = null!;
    public Address Address {get; set; } = null!;
}
