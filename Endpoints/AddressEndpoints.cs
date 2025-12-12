using IsabelliDoces.Data;
using IsabelliDoces.Dtos.AddressDtos;
using IsabelliDoces.Entities;
using IsabelliDoces.Utilities;
using Microsoft.EntityFrameworkCore;

namespace IsabelliDoces.Endpoints;

public static class GenreEndpoints
{
    public static RouteGroupBuilder MapAddressesEndPoints(this WebApplication app)
    {
        var group = app.MapGroup("addresses");

        group.MapGet("/", async (IsabelliDocesContext dbContext) =>
                await dbContext.Addresses
                    .Select(g => g.Map<Address, AddressDetailsDto>(0))
                    .ToListAsync()
                );

        return group;
    }
}
