using IsabelliDoces.Enums;
using IsabelliDoces.Utilities;

namespace IsabelliDoces.Entities;

public class Order() : Entity
{
    [AttributePresentation(Label = "Cliente")]
    public required Client Client { get; init; }

    [AttributePresentation(Label = "Data de Realização")]
    public DateTime AccomplishDate { get; set; } = DateTime.Today;

    [AttributePresentation(Label = "Data de Entrega")]
    public DateTime DeliveryDate { get; set; }

    [AttributePresentation(Label = "Local de Entregua")]
    public Address Address { get; set; } = null!;

    [AttributePresentation(Label = "Status do Pedido")]
    public OrderStatus Status { get; set; } = OrderStatus.ACTIVE;
}
