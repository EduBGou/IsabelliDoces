using IsabelliDoces.Data;
using IsabelliDoces.Dtos.ClientDtos;
using IsabelliDoces.Entities;
using IsabelliDoces.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IsabelliDoces.Endpoints;

public static class GamesEndpoints
{
    const string GET_CLIENT_ENDPOINT_NAME = "GetClient";

    public static RouteGroupBuilder MapClientsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("clients").WithParameterValidation();

        // GET /clients/
        group.MapGet("/", async (IsabelliDocesContext dbContext) =>
            await dbContext.Clients
                .Include(c => c.Home)
                .Select(c => c.Map<Client, ClientSummaryDto>(0))
                .AsNoTracking()
                .ToListAsync()
        );


        // GET /clients/{id}
        group.MapGet("/{id}", async (int id, IsabelliDocesContext dbContext) =>
        {
            Client? client = await dbContext.Clients.FindAsync(id);
            return client is null ? Results.NotFound() : Results.Ok(client.Map<Client, ClientDetailsDto>());

        }).WithName(GET_CLIENT_ENDPOINT_NAME);


        // POST /clients/
        group.MapPost("/", async ([FromBody] CreateClientDto newClient, IsabelliDocesContext dbContext) =>
        {
            var client = newClient.Map<CreateClientDto, Client>();

            dbContext.Clients.Add(client);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(
                GET_CLIENT_ENDPOINT_NAME,
                new { id = client.Id },
                client.Map<Client, ClientDetailsDto>()
            );
        });


        // PUT /clients/{id}
        group.MapPut("/{id}", async (int id, UpdateClientDto updatedClient, IsabelliDocesContext dbContext) =>
        {
            var existingClient = await dbContext.Clients.FindAsync(id);

            if (existingClient is null)
            {
                return Results.NotFound();
            }

            dbContext.Clients.Entry(existingClient).CurrentValues.SetValues(updatedClient.Map<UpdateClientDto, Client>(id));
            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });


        // DELETE /clients/{id}
        group.MapDelete("/{id}", async (int id, IsabelliDocesContext dbcontext) =>
        {
            await dbcontext.Clients.Where(g => g.Id.Equals(id)).ExecuteDeleteAsync();
            return Results.NoContent();
        });

        return group;
    }
}
