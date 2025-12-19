using IsabelliDoces.Data;
using IsabelliDoces.Enums;
using IsabelliDoces.Interfaces;
using IsabelliDoces.Relations;
using IsabelliDoces.UI.Helpers;
using IsabelliDoces.Utilities;
using Microsoft.EntityFrameworkCore;

namespace IsabelliDoces.Entities;

public class Client() : Entity, INameable   
{
    [AttributePresentation(Label = "Nome", ListingOrder = 2)]
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public Address? Home { get; set; }

    public async Task<List<Address>> ListingDeliveryPlacesAddresses(IsabelliDocesContext dbContext, bool print = true)
    {
        return [.. (await ListingHelper.ListingAsync<DeliveryPlace>(dbContext, print, q => q
            .Include(dp => dp.Client).Include(dp => dp.Address)
            .Where(dp => dp.Client.Id == Id))).Select(dp => dp.Address)];
    }

    public async Task<List<Order>> ListingActiveOrdes(IsabelliDocesContext dbContext, bool print = true)
    {
        return await ListingHelper.ListingAsync<Order>(dbContext, print, q => q
            .Include(o => o.Client).Include(o => o.DeliveryAddress)
            .Where(o => o.Client.Id == Id && o.Status == OrderStatus.ACTIVE));
    }
    public override string ToString() => Name;
}
