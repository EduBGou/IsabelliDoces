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
    public required DateTime DeliveryDate { get; set; }

    public int LocalId { get; set; }
    [AttributePresentation(Label = "Local de Entregua")]
    public required Address DeliveryPlace { get; set; }

    [AttributePresentation(Label = "Status do Pedido")]
    public OrderStatus Status { get; set; } = OrderStatus.ACTIVE;
}
