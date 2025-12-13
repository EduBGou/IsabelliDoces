using IsabelliDoces.Data;
using IsabelliDoces.Enums;
using IsabelliDoces.UI.Helpers;
using IsabelliDoces.Utilities;
using Microsoft.EntityFrameworkCore;

namespace IsabelliDoces.Entities;

public class Order() : Entity
{
    [AttributePresentation(Label = "Cliente", ListingOrder = 2)]
    public required Client Client { get; init; }

    [AttributePresentation(Label = "Data de Realização", ListingOrder = 3)]
    public DateTime AccomplishDate { get; set; } = DateTime.Today;

    [AttributePresentation(Label = "Data de Entrega", ListingOrder = 4)]
    public DateTime DeliveryDate { get; set; }

    [AttributePresentation(Label = "Local de Entrega")]
    public Address DeliveryAddress { get; set; } = null!;

    [AttributePresentation(Label = "Status do Pedido", ListingOrder = 5)]
    public OrderStatus Status { get; set; } = OrderStatus.ACTIVE;


    public async Task<List<OrderLine>> ListingLinesAsync(IsabelliDocesContext dbContext, bool print = true)
    {
        if (print) Console.WriteLine($"\nEstas são as linhas do pedido:");
        return await ListingHelper.ListingAsync<OrderLine>(dbContext, print, q => q
            .Include(ol => ol.Order).Include(ol => ol.CakeFlavor)
            .Where(ol => ol.Order!.Id == Id));
    }

    public async Task<decimal> GetPrice(IsabelliDocesContext dbContext)
    {
        decimal sum = 0;
        var orderLines = await ListingLinesAsync(dbContext, false);
        foreach (var ol in orderLines)
        {
            sum += ol.CakeFlavor!.Price * ol.Amount;
        }
        return sum;
    }
}
