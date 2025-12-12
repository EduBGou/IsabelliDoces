using IsabelliDoces.Entities;
using Microsoft.EntityFrameworkCore;

namespace IsabelliDoces.Relations;

public class DeliveryPlace()
{
    public Client Client { get; set; } = null!;
    public Address Address {get; set; } = null!;
}
