namespace IsabelliDoces.Entities;

public class Client() : Entity
{
    public string Name { get; set; }  = string.Empty;
    public Address? Address { get; set; }
    public string Phone { get; set; } = string.Empty;

    public override string ToString() =>
        $"[{Id}]: {nameof(Name)} = {Name,30}, {nameof(Phone)} = {Phone,10}, {nameof(Address)} = {Address}";
}
