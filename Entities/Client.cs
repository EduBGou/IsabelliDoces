namespace IsabelliDoces.Entities;

public class Client
{
    public Client()
    {

    }

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int AddressId { get; set; }
    public Address? Address { get; set; }
    public string Phone { get; set; } = string.Empty;

    public override string ToString() =>
        $"[{Id}]: {nameof(Name)} = {Name, 30}, {nameof(Phone)} = {Phone, 10}, {nameof(Address)} = {Address}";
}
